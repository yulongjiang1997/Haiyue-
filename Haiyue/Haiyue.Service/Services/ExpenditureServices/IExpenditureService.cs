using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Expenditures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.ExpenditureServices
{
    public interface IExpenditureService
    {
        /// <summary>
        /// 添加支出
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(AddOrEditExpenditureDto model);

        /// <summary>
        /// 删除支出
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑支出
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> EditAsync(int id, AddOrEditExpenditureDto model);

        /// <summary>
        /// 分页查询支出
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPaginSelectDto<ReturnExpenditureDto>> QueryPaginAsync(SelectExpenditureDto model);
    }
}
