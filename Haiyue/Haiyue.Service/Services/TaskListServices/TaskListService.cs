using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Haiyue.HYEF;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.TaskLists;
using Haiyue.Model.Enums;
using Haiyue.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Haiyue.Service.Services.TaskListServices
{
    public class TaskListService : ITaskListService
    {
        private readonly HYContext _context;
        private readonly IMapper _mapper;

        public TaskListService(HYContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(AddOrEditTaskListDto model)
        {
            var taskList = _mapper.Map<TaskList>(model);
            _context.TaskLists.Add(taskList);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var taskList = await _context.TaskLists.FirstOrDefaultAsync(i => i.Id == id);
            if (taskList != null)
            {
                _context.TaskLists.Remove(taskList);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditAsync(int id, AddOrEditTaskListDto model)
        {
            var taskList = await _context.TaskLists.FirstOrDefaultAsync(i => i.Id == id);
            if (taskList != null)
            {
                _mapper.Map(model, taskList);
                var taskChangeLog = _mapper.Map<TaskChangeLog>(model);
                taskChangeLog.TaskId = id;
                _context.TaskChangeLogss.Add(taskChangeLog);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditTaskStatus(int id, AddTaskStatusLogDto model)
        {
            var tasklist = await _context.TaskLists.FirstOrDefaultAsync(i => i.Id == id);
            if (tasklist != null)
            {
                tasklist.TaskStatus = model.ChangeStatus;
                var taskListStatusLog = _mapper.Map<TaskStatusLog>(model);
                taskListStatusLog.TaskId = id;
                _context.TaskStatusLogss.Add(taskListStatusLog);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnPaginSelectDto<ReturnTaskListDto>> QueryPaginAsync(SelectTaskListDto model)
        {
            var result = new ReturnPaginSelectDto<ReturnTaskListDto>();
            var taskList = from t in _context.TaskLists.Include(i => i.TaskChangeLogs).Include(i => i.TaskStatusLogs)
                           join au in _context.Users on t.AssignId equals au.Id
                           join pu in _context.Users on t.PublisherId equals pu.Id
                           orderby t.CreateTime
                           select new ReturnTaskListDto()
                           {
                               AssignName = au.Name,
                               BeginTime = t.BeginTime,
                               Content = t.Content,
                               EndTime = t.EndTime,
                               PublisherName = pu.Name,
                               TaskChangeLogs = _mapper.Map<List<ReturnTaskChangeLogDto>>(t.TaskChangeLogs.ToList()),
                               TaskStatusLogs = _mapper.Map<List<ReturnTaskStatueLogDto>>(t.TaskStatusLogs.ToList()),
                               TaskStatus = t.TaskStatus,
                               Title = t.Title,
                               CreateTime=t.CreateTime
                           };

            if(model.BeginTime.HasValue)
            {
                taskList = taskList.Where(i => i.CreateTime >= model.BeginTime);
            }

            if (model.EndTime.HasValue)
            {
                taskList = taskList.Where(i => i.CreateTime <= model.EndTime);
            }

            if (model.TaskDelegationType.HasValue)
            {
                var user = await _context.Users.FirstOrDefaultAsync(i => i.Id == model.UserId);
                if(model.TaskDelegationType==TaskDelegationType.BeAuthorised)
                {
                    taskList = taskList.Where(i=>i.AssignName==user.Name);
                }
                if(model.TaskDelegationType==TaskDelegationType.Sponsor)
                {
                    taskList = taskList.Where(i => i.PublisherName == user.Name);
                }
                
            }

            if(model.TaskStatusType.HasValue)
            {
                taskList = taskList.Where(i => i.TaskStatus == model.TaskStatusType);
            }

            switch (model.SelectCondition)
            {
                case "*": taskList = taskList.Where(i=>EF.Functions.Like(i.Title,$"{model.SelectKeyword}")||
                                                       EF.Functions.Like(i.Content, $"{model.SelectKeyword}")||
                                                       EF.Functions.Like(i.PublisherName, $"{model.SelectKeyword}"));
                    break;
                default:
                    break;
            }

            result.Amount = model.Amount;
            result.Total = await taskList.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Items = await taskList.Pagin(model).ToListAsync();
            return result;
        }
    }
}
