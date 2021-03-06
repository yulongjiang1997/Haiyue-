﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haiyue.Model;
using Haiyue.Model.Dto.TaskLists;
using Haiyue.Service.Services.TaskListServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Haiyue.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskListService _service;

        public TaskListController(ITaskListService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(AddOrEditTaskListDto model)
        {
            var result = new ReturnData<bool>();

            result.Obj = await _service.CreateAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = new ReturnData<bool>();

            result.Obj = await _service.DeleteAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// 修改任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> EditAsync(int id, AddOrEditTaskListDto model)
        {
            var result = await _service.EditAsync(id, model);

            return Ok(result);
        }

        /// <summary>
        /// 修改任务状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("EditTaskStatus")]
        public async Task<IActionResult> EditTaskStatus(int id, AddTaskStatusLogDto model)
        {
            var result = await _service.EditTaskStatus(id, model);

            return Ok(result);
        }

        /// <summary>
        /// 分页查询任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPagin")]
        public async Task<IActionResult> QueryPaginAsync(SelectTaskListDto model)
        {

            var result = await _service.QueryPaginAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 根据用户分页查询任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPaginByUser")]
        public async Task<IActionResult> QueryPaginByUserAsync(SelectTaskListDto model)
        {

            var result = await _service.QueryPaginByUser(model);

            return Ok(result);
        }

        /// <summary>
        /// 修改任务阅读状态为已阅读
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("EditIsHave")]
        public async Task<IActionResult> EditIsHave(int taskId,string userId)
        {
            var result = new ReturnData<bool>();

            result.Obj = await _service.EditTaskHaveReadStatus(taskId, userId);

            return Ok(result);
        }

        /// <summary>
        /// 根据用户ID获得未读任务
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHaveStatusIsNo")]
        public async Task<IActionResult> GetHaveStatusIsNo(string userId)
        {
            var result = await _service.GetHaveStatusIsNo(userId);

            return Ok(result);
        }
    }
}