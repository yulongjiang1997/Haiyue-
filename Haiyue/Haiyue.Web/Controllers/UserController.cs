using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haiyue.Model;
using Haiyue.Model.Dto.Users;
using Haiyue.Service.Services.UserServices;
using Haiyue.Web.ActionFilter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Haiyue.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserservice _service;
        public UserController(IUserservice service)
        {
            _service = service;
        }

        /// <summary>
        /// 获得所有权限名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetJurisdictionType")]
        public IActionResult GetJurisdictionType()
        {
            return Ok(_service.GetJurisdictionType());
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(UserAddOrEditDto model)
        {
            var result = await _service.CreateUserAsync(model);
            return Ok(result);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = new ReturnData<bool>();
            result.Obj = await _service.DeleteUserByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> EditAsync(string id, UserAddOrEditDto model)
        {
            var result = await _service.EditUserByIdAsync(id, model);
            return Ok(result);
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Query")]
        public async Task<IActionResult> QueryAsync(SelectUserDto model)
        {
            var result = await _service.QueryPaginAsync(model);
            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(LoginDto model)
        {
            var result = new ReturnData<ReturnLoginDto>();
            result.Obj = await _service.Login(model);
            if (result.Obj ==null)
            {
                result.Success = false;
                result.Message = "登录失败，用户名或密码错误";
            }
            return Ok(result);
        }


    }
}