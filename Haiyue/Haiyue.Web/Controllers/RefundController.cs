using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haiyue.Model;
using Haiyue.Model.Dto.Refunds;
using Haiyue.Service.Services.RefundServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Haiyue.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefundController : ControllerBase
    {
        private readonly IRefundService _service;

        public RefundController(IRefundService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加退款记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(AddOrEditRefundDto model)
        {
            var result = new ReturnData<bool>();

            result.Obj = await _service.CreateAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 删除退款记录
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
        /// 修改退款记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> EditAsync(int id, AddOrEditRefundDto model)
        {
            var result = await _service.EditAsync(id, model);

            return Ok(result);
        }

        /// <summary>
        /// 分页查询退款记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPagin")]
        public async Task<IActionResult> QueryPaginAsync(SelectRefundDto model)
        {

            var result = await _service.QueryPaginAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 修改退款状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("EditRefundStatus")]
        public async Task<IActionResult> EditRefundStatusAsync(int id)
        {
            var result = new ReturnData<bool>();
            result.Obj = await _service.EditRefundStatusAsync(id);
            return Ok(result);
        }

    }
}