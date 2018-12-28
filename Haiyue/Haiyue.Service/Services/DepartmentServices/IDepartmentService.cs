using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Departments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(DepartmentAddOrEditDto model);

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑部门
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> EditAsync(int id, DepartmentAddOrEditDto model);

        /// <summary>
        /// 分页查询部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPaginSelectDto<ReturnDepartmentDto>> QueryPaginAsync(SelectDepartmentDto model);
    }
}
