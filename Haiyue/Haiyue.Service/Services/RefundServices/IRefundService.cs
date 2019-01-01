using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Refunds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.RefundServices
{
    public interface IRefundService
    {
        /// <summary>
        /// 添加退款申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(AddOrEditRefundDto model);

        /// <summary>
        /// 删除退款申请
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑退款申请
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> EditAsync(int id, AddOrEditRefundDto model);

        /// <summary>
        /// 分页查询退款申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPaginSelectDto<ReturnRefundDto>> QueryPaginAsync(SelectRefundDto model);
    }
}
