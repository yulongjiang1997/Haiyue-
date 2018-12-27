﻿using Haiyue.Model.Dto;
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
        Task<bool> CreateAsync(UserAddOrEditDto model);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> EditAsync(int id, UserAddOrEditDto model);

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
    }
}