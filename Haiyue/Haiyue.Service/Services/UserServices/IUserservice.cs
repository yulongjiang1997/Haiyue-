using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Admin;
using Haiyue.Model.Dto.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.UserServices
{
    public interface IUserservice
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CreateUserAsync(UserAddOrEditDto model);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteUserByIdAsync(int id);

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> EditUserByIdAsync(int id, UserAddOrEditDto model);

        /// <summary>
        /// 分页查询游戏
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPaginSelectDto<ReturnUserDto>> QueryPaginAsync(SelectUserDto model);

        /// <summary>
        /// 获得所有权限列表
        /// </summary>
        /// <returns></returns>
        List<ReturnJurisdictionTypeDto> GetJurisdictionType();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnLoginDto> Login(LoginDto model);

        /// <summary>
        /// 检查token是否超时
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        bool CheckTokenTimeOut(int userId, string token);

        /// <summary>
        /// 检查是否为管理员
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool CheckIsAdmin(int userId);
    }
}
