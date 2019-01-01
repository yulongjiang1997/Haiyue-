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
                taskChangeLog.OperatorId = model.PublisherId;
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
            var taskList = from t in _context.TaskLists
                           join au in _context.Users on t.AssignId equals au.Id
                           join pu in _context.Users on t.PublisherId equals pu.Id
                           orderby t.CreateTime
                           select new ReturnTaskListDto()
                           {
                               Id=t.Id,
                               AssignName = au.Name,
                               BeginTime = t.BeginTime,
                               Content = t.Content,
                               EndTime = t.EndTime,
                               PublisherName = pu.Name,
                               TaskChangeLogs = null,
                               TaskStatusLogs = null,
                               TaskStatus = t.TaskStatus,
                               Title = t.Title,
                               CreateTime=t.CreateTime
                           };

            var pagin = await taskList.Pagin(model).ToListAsync();

            foreach (var item in pagin)
            {
                item.TaskChangeLogs = _mapper.Map<List<ReturnTaskChangeLogDto>>(await _context.TaskChangeLogss.Include(i=>i.Operator).Where(i => i.TaskId == item.Id).ToListAsync());
                item.TaskStatusLogs = _mapper.Map<List<ReturnTaskStatueLogDto>>(await _context.TaskStatusLogss.Where(i => i.TaskId == item.Id).ToListAsync());
            }
            var resultPagin = pagin.AsQueryable();
            if (model.BeginTime.HasValue)
            {
                resultPagin = resultPagin.Where(i => i.CreateTime >= model.BeginTime);
            }

            if (model.EndTime.HasValue)
            {
                resultPagin = resultPagin.Where(i => i.CreateTime <= model.EndTime);
            }

            if (model.TaskDelegationType.HasValue)
            {
                var user = await _context.Users.FirstOrDefaultAsync(i => i.Id == model.UserId);
                if(model.TaskDelegationType==TaskDelegationType.BeAuthorised)
                {
                    resultPagin = resultPagin.Where(i=>i.AssignName==user.Name);
                }
                if(model.TaskDelegationType==TaskDelegationType.Sponsor)
                {
                    resultPagin = resultPagin.Where(i => i.PublisherName == user.Name);
                }
                
            }

            if(model.TaskStatusType.HasValue)
            {
                resultPagin = resultPagin.Where(i => i.TaskStatus == model.TaskStatusType);
            }

            switch (model.SelectCondition)
            {
                case "*":
                    resultPagin = resultPagin.Where(i=>EF.Functions.Like(i.Title,$"{model.SelectKeyword}")||
                                                       EF.Functions.Like(i.Content, $"{model.SelectKeyword}")||
                                                       EF.Functions.Like(i.PublisherName, $"{model.SelectKeyword}"));
                    break;
                default:
                    break;
            }
            

            result.Amount = model.Amount;
            result.Total = await taskList.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Items =  resultPagin.ToList();
            return result;
        }
    }
}
