using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haiyue.Model;
using Haiyue.Model.Dto.Departments;
using Haiyue.Service.Services.DepartmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Haiyue.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(DepartmentAddOrEditDto model)
        {
            var result = await _service.CreateAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 删除部门
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
        /// 修改部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> EditAsync(int id, DepartmentAddOrEditDto model)
        {
            var result = await _service.EditAsync(id, model);

            return Ok(result);
        }

        /// <summary>
        /// 分页查询部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPagin")]
        public async Task<IActionResult> QueryPaginAsync(SelectDepartmentDto model)
        {

            var result = await _service.QueryPaginAsync(model);

            return Ok(result);
        }
    }
}