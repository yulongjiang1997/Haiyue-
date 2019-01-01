using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haiyue.Model;
using Haiyue.Model.Dto.OtherOrders;
using Haiyue.Service.Services.OtherOrderServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Haiyue.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherOrderController : ControllerBase
    {
        private readonly IOtherOrderService _service;

        public OtherOrderController(IOtherOrderService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加其他订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(AddOrEditOtherOrderDto model)
        {
            var result = new ReturnData<bool>();

            result.Obj = await _service.CreateAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 删除其他订单
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
        /// 修改其他订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> EditAsync(int id, AddOrEditOtherOrderDto model)
        {
            var result = new ReturnData<bool>();

            result.Obj = await _service.EditAsync(id, model);

            return Ok(result);
        }

        /// <summary>
        /// 分页查询其他订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPagin")]
        public async Task<IActionResult> QueryPaginAsync(SelectOtherOrderDto model)
        {

            var result = await _service.QueryPaginAsync(model);

            return Ok(result);
        }
    }
}