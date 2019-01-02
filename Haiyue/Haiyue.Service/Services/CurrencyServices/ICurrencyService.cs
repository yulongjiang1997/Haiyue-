using Haiyue.Model;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Currencys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.CurrencyServices
{
    public interface ICurrencyService
    {
        /// <summary>
        /// 添加汇率
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> CreateAsync(CurrencyAddOrEditDto model);

        /// <summary>
        /// 删除汇率
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑汇率
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> EditAsync(int id, CurrencyAddOrEditDto model);

        /// <summary>
        /// 分页查询汇率
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPaginSelectDto<ReturnCurrencyDto>> QueryPaginAsync(SelectCurrencyDto model);

        /// <summary>
        /// 查询所有货币类型
        /// </summary>
        /// <returns></returns>
        Task<List<ReturnQueryAllDto>> QueryAllAsync();

    }
}
