using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haiyue.Model;
using Haiyue.Model.Dto.Currencys;
using Haiyue.Service.Services.CurrencyServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Haiyue.Web.Controllers
{
    /// <summary>
    /// 汇率管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _service;

        public CurrencyController(ICurrencyService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加汇率
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(CurrencyAddOrEditDto model)
        {
            var result = new ReturnData<bool>();

            result.Obj = await _service.CreateAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 删除汇率
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
        /// 修改汇率
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> EditAsync(int id, double exchangeRate)
        {
            var result = new ReturnData<bool>();

            result.Obj = await _service.EditAsync(id, exchangeRate);

            return Ok(result);
        }

        /// <summary>
        /// 分页查询汇率
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPagin")]
        public async Task<IActionResult> QueryPaginAsync(SelectCurrencyDto model)
        {

            var result = await _service.QueryPaginAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 查询所有货币
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryAll")]
        public async Task<IActionResult> QueryAllAsync()
        {
            var result = new ReturnData<List<ReturnQueryAllDto>>();
            result.Obj = await _service.QueryAllAsync();
            return Ok(result);
        }
    }
}