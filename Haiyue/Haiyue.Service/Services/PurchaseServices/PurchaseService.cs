using System;
using System.Linq;
using System.Threading.Tasks;
using EPMS.Model.Dto.Purchase;
using EPMS.Model.Enums;
using Haiyue.EF;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Purchase;
using Haiyue.Model.Model;
using Haiyue.Service;
using Microsoft.EntityFrameworkCore;

namespace EPMS.Service.Services.PurchaseServices
{
    public class PurchaseService : IPurchaseService
    {
        private readonly HYContext _context;

        public PurchaseService(HYContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(PurchaseAddOrEditDto model)
        {
            var currency = await _context.Currencys.FirstOrDefaultAsync(i=>i.Id==model.Currency);
            if(currency!=null)
            {
                _context.Purchases.Add(new Purchase()
                {
                    CreateTime = DateTime.Now,
                    CurrencyId = model.Currency,
                    GameId = model.GameId,
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
                    UnitPrice = model.UnitPrice,
                    Handler = model.Handler,
                    RealIncomeRMB = model.RealIncome * currency.ExchangeRate
                });
            }
            else
            {
                throw new Exception("没找到指定币种");
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _context.Purchases.FirstOrDefaultAsync(i => i.Id == id);
            if (result != null)
            {
                _context.Purchases.Remove(result);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditAsync(int id, PurchaseAddOrEditDto model)
        {
            var result = await _context.Purchases.FirstOrDefaultAsync(i => i.Id == id);
            var currency = await _context.Currencys.FirstOrDefaultAsync(i => i.Id == model.Currency);
            if (result != null)
            {
                result.CurrencyId = model.Currency;
                result.GameId = model.GameId;
                result.LastUpTime = DateTime.Now;
                result.Number = model.Number;
                result.OrderDate = model.OrderDate;
                result.OrderNumber = model.OrderNumber;
                result.PaymentAccount = model.PaymentAccount;
                result.PaymentStatus = model.PaymentStatus;
                result.RealIncome = model.RealIncome;
                result.Remarks = model.Remarks;
                result.ServerName = model.ServerName;
                result.SupplierPhone = model.SupplierPhone;
                result.TotalNumber = model.TotalNumber;
                result.TotalPrice = model.TotalPrice;
                result.UnitPrice = model.UnitPrice;
                result.RealIncomeRMB = model.RealIncome * currency.ExchangeRate;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditPaymentStatusAsync(int id)
        {
            var purchase = await _context.Purchases.FirstOrDefaultAsync(i => i.Id == id && i.PaymentStatus == PaymentStatusType.Unpaid);
            if (purchase != null)
            {
                purchase.PaymentStatus = PaymentStatusType.AlreadyPaid;
            }
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnPaginSelectDto<ReturnPuurchaseDto>> QueryPaginAsync(SelectPurchaseDto model)
        {
            var result = new ReturnPaginSelectDto<ReturnPuurchaseDto>();
            var purchases = from p in _context.Purchases
                            join g in _context.Games on p.GameId equals g.Id
                            join c in _context.Currencys on p.CurrencyId equals c.Id
                            select new ReturnPuurchaseDto()
                            {
                                CreateTime = p.CreateTime,
                                CurrencyName = c.Name,
                                OrderNumber = p.OrderNumber,
                                GameName = g.Name,
                                Id = p.Id,
                                Number = p.Number,
                                OrderDate = p.OrderDate,
                                PaymentAccount = p.PaymentAccount,
                                PaymentStatus = p.PaymentStatus,
                                RealIncome = p.RealIncome,
                                Remarks = p.Remarks,
                                ServerName = p.ServerName,
                                SupplierPhone = p.SupplierPhone,
                                TotalNumber = p.TotalNumber,
                                TotalPrice = p.TotalPrice,
                                UnitPrice = p.UnitPrice,
                                Handler = p.Handler,
                                RealIncomeRMB = p.RealIncomeRMB
                            };

           

            result.Total = await purchases.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Amount = model.Amount;
            result.Items = await purchases.Pagin(model).OrderBy(i => i.CreateTime).ToListAsync();

            return result;
        }
    }
}
