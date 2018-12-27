using Haiyue.Model.Dto.Purchase;
using Haiyue.Model.Enums;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Purchase;
using Haiyue.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.PurchaseServices
{
    public interface IPurchaseService
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(PurchaseAddOrEditDto model);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> EditAsync(int id, PurchaseAddOrEditDto model);

        /// <summary>
        /// 修改付款状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statusType"></param>
        /// <returns></returns>
        Task<bool> EditPaymentStatusAsync(int id);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPaginSelectDto<ReturnPuurchaseDto>> QueryPaginAsync(SelectPurchaseDto model);
    }
}
