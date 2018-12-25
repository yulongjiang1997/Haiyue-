using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EF;
using EPMS.Model.Dto.Purchase;
using EPMS.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace EPMS.Service.Services.PurchaseServices
{
    public class PurchaseService : IPurchaseService
    {
        private readonly EPMSContext _context;

        public PurchaseService(EPMSContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(PurchaseAddOrEditDto model)
        {
            _context.Purchases.Add(new Purchase()
            {
                CreateTime = DateTime.Now,
                Currency = model.Currency,
                Game = model.Game,
                LastUpTime = DateTime.Now,
                Number = model.Number,
                OrderDate = model.OrderDate,
                OrderNumber = model.OrderNumber,
                PaymentAccount = model.PaymentAccount,
                PaymentStatus = model.PaymentStatus,
                RealIncome = model.RealIncome,
                Remarks = model.Remarks,
                ServerName = model.ServerName,
                SupplierPhone = model.SupplierPhone,
                TotalNumber = model.TotalNumber,
                TotalPrice = model.TotalPrice,
                UnitPrice = model.UnitPrice
            });

            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _context.Purchases.FirstOrDefaultAsync(i => i.Id == id);
            if(result!=null)
            {
                _context.Purchases.Remove(result);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> EditAsync(int id, PurchaseAddOrEditDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Purchase>> QueryPaginAsync()
        {
            var result =  _context.Purchases.AsNoTracking();

            return await result.ToListAsync();
        }
    }
}
