using Haiyue.Model.Dto;
using Haiyue.Model.Dto.OtherOrders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.OtherOrderServices
{
    public interface IOtherOrderService
    {
        /// <summary>
        /// 添加其他订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(AddOrEditOtherOrderDto model);

        /// <summary>
        /// 删除其他订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑其他订单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> EditAsync(int id, AddOrEditOtherOrderDto model);

        /// <summary>
        /// 分页查询其他订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPaginSelectDto<ReturnOtherOrderDto>> QueryPaginAsync(SelectOtherOrderDto model);
    }
}
