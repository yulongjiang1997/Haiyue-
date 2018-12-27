﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Haiyue.Model.Dto.Purchase;
using Haiyue.Model.Enums;
using Haiyue.HYEF;
using Haiyue.Model.Dto;
using Haiyue.Model.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Haiyue.Service.Services.PurchaseServices
{
    public class PurchaseService : IPurchaseService
    {
        private readonly HYContext _context;
        private readonly IMapper _mapper;

        public PurchaseService(HYContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(PurchaseAddOrEditDto model)
        {
            var currency = await _context.Currencys.FirstOrDefaultAsync(i => i.Id == model.CurrencyId);
            if (currency != null)
            {
                var purchases = _mapper.Map<Purchase>(model);
                purchases.RealIncomeRMB = model.RealIncome * currency.ExchangeRate;
                _context.Purchases.Add(purchases);
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
            var currency = await _context.Currencys.FirstOrDefaultAsync(i => i.Id == model.CurrencyId);
            if (result != null)
            {
                _mapper.Map(model, result);
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
            var purchases = _context.Purchases.Include(i => i.Game).Include(i => i.Currency).AsNoTracking();


            #region 高级筛选
            //筛选所选游戏数据
            if (model.GameId.HasValue)
            {
                purchases = purchases.Where(i => i.Game.Id == model.GameId);
            }

            //筛选所选付款状态
            if (model.PaymentStatus.HasValue)
            {
                purchases = purchases.Where(i => i.PaymentStatus == model.PaymentStatus);
            }

            //筛选符合输入的订单号的数据
            if (!string.IsNullOrEmpty(model.OrderNumber))
            {
                purchases = purchases.Where(i => EF.Functions.Like(i.OrderNumber, $"{model.OrderNumber}"));
            }

            //筛选符合输入的服务器名称的数据
            if (!string.IsNullOrEmpty(model.ServerName))
            {
                purchases = purchases.Where(i => EF.Functions.Like(i.ServerName, $"{model.ServerName}"));
            }

            //筛选输入的供应商联系方式的数据
            if (!string.IsNullOrEmpty(model.SupplierPhone))
            {
                purchases = purchases.Where(i => EF.Functions.Like(i.SupplierPhone, $"{model.SupplierPhone}"));
            }

            //开始时间
            if(model.BeginTime.HasValue)
            {
                purchases = purchases.Where(i => i.CreateTime >= model.BeginTime);
            }

            //结束时间
            if (model.EndTime.HasValue)
            {
                purchases = purchases.Where(i => i.CreateTime <= model.EndTime);
            }
            #endregion

            result.Total = await purchases.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Amount = model.Amount;
            result.Items = _mapper.Map<List<ReturnPuurchaseDto>>(await purchases.Pagin(model).OrderBy(i => i.CreateTime).ToListAsync());

            return result;
        }
    }
}
