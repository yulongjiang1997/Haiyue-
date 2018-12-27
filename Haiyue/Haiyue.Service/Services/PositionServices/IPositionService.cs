using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Positions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.PositionServices
{
    public interface IPositionService
    {
        /// <summary>
        /// 添加职位
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(PositionAddOrEditDto model);

        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑职位
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> EditAsync(int id, PositionAddOrEditDto model);

        /// <summary>
        /// 分页查询职位
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPaginSelectDto<ReturnPositionDto>> QueryPaginAsync(SelectPositionDto model);
    }
}
