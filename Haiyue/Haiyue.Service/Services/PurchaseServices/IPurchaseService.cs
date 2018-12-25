using EPMS.Model.Dto.Purchase;
using EPMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Service.Services.PurchaseServices
{
    public interface IPurchaseService
    {
        Task<bool> CreateAsync(PurchaseAddOrEditDto model);

        Task<bool> DeleteAsync(int id);

        Task<bool> EditAsync(int id, PurchaseAddOrEditDto model);

        Task<List<Purchase>> QueryPaginAsync();
    }
}
