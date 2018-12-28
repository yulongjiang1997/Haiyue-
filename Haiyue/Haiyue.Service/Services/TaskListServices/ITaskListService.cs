using Haiyue.Model.Dto;
using Haiyue.Model.Dto.TaskLists;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.TaskListServices
{
    public interface ITaskListService
    {
        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(AddOrEditTaskListDto model);

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑任务
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> EditAsync(int id, AddOrEditTaskListDto model);

        /// <summary>
        /// 修改任务状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        Task<bool> EditTaskStatus(int id, AddTaskStatusLogDto model);

        /// <summary>
        /// 分页查询任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPaginSelectDto<ReturnTaskListDto>> QueryPaginAsync(SelectTaskListDto model);
    }
}
