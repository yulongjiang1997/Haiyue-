using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haiyue.Model;
using Haiyue.Model.Dto.LeaveAMessages;
using Haiyue.Model.Dto.LeaveAMessages.LeaveAMessageReplys;
using Haiyue.Service.Services.LeaveAMessageServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Haiyue.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAMessageController : ControllerBase
    {
        private readonly ILeaveAMessageService _service;

        public LeaveAMessageController(ILeaveAMessageService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加留言
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(AddOrEditLeaveAMessageDto model)
        {
            var result = new ReturnData<bool>();

            result.Obj = await _service.CreateAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 删除留言
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync(int id,string userId)
        {
            var result = await _service.DeleteAsync(id, userId);

            return Ok(result);
        }

        /// <summary>
        /// 添加留言回复
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateReply")]
        public async Task<IActionResult> CreateReplyAsync(AddOrEditLeaveAMessageReplyDto model)
        {
            var result = new ReturnData<bool>();

            result.Obj = await _service.CreateReplyAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 删除留言回复
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteReply")]
        public async Task<IActionResult> DeleteReplyAsync(int id,string userId)
        {
            var result = await _service.DeleteReplyAsync(id, userId);

            return Ok(result);
        }

        /// <summary>
        /// 修改留言
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> EditAsync(int id, AddOrEditLeaveAMessageDto model)
        {
            var result = await _service.EditAsync(id, model);

            return Ok(result);
        }

        /// <summary>
        /// 分页查询留言
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPagin")]
        public async Task<IActionResult> QueryPaginAsync(SelectLeaveAMessageDto model)
        {
            var result = await _service.QueryPaginAsync(model);

            return Ok(result);
        }
    }
}