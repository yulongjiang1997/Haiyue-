using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Expenditures.ExpenditureTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.ExpenditureServices.ExpenditureTypeServices
{
    public interface IExpenditureTypeService
    {
        /// <summary>
        /// 添加支出类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(AddOrEditExpeditureTypeDto model);

        /// <summary>
        /// 删除支出类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 分页查询支出类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPaginSelectDto<ReturnExpeditureTypeDto>> QueryPaginAsync(SelectExpeditureTypeDto model);
    }
}
