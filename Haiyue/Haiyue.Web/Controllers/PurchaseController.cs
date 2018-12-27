using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPMS.Model;
using EPMS.Model.Dto.Purchase;
using Haiyue.Model.Model;
using EPMS.Service.Services.PurchaseServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Haiyue.Model.Dto.Purchase;
using Haiyue.Model.Dto;

namespace EPMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _service;

        public PurchaseController(IPurchaseService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(PurchaseAddOrEditDto model)
        {
            var result = new ReturnData<bool>();

            result.Obj = await _service.CreateAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id"></param>
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
        /// 查询订单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Query")]
        public async Task<IActionResult> QueryAsync(SelectPurchaseDto model)
        {
            var result = new ReturnData<ReturnPaginSelectDto<ReturnPuurchaseDto>>();
            result.Obj = await _service.QueryPaginAsync(model);
            return Ok(result);
        }

        /// <summary>
        /// 编辑订单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> EditAsync(int id, PurchaseAddOrEditDto model)
        {
            var result = new ReturnData<bool>();

            result.Obj = await _service.EditAsync(id, model);

            return Ok(result);
        }

        /// <summary>
        /// 修改付款状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("EditPaymentStatus")]
        public async Task<IActionResult> EditPaymentStatusAsync(int id)
        {
            var result = new ReturnData<bool>();
            result.Obj = await _service.EditPaymentStatusAsync(id);
            return Ok(result);
        }
    }
}