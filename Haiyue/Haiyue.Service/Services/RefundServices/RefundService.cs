using AutoMapper;
using Haiyue.HYEF;
using Haiyue.Model;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Refunds;
using Haiyue.Model.Enums;
using Haiyue.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.RefundServices
{
    public class RefundService : IRefundService
    {
        private readonly HYContext _context;
        private readonly IMapper _mapper;

        public RefundService(HYContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(AddOrEditRefundDto model)
        {
            var refund = _mapper.Map<Refund>(model);
            _context.Refunds.Add(refund);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var refund = await _context.Refunds.FirstOrDefaultAsync(i => i.Id == id);
            _context.Refunds.Remove(refund);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnData<bool>> EditAsync(int id, AddOrEditRefundDto model)
        {
            var returnResult = new ReturnData<bool>();
            var refund = await _context.Refunds.FirstOrDefaultAsync(i => i.Id == id);
            if (refund != null)
            {
                var checkTime = CheckLastUpDateTime.Check(model.LastUpDateTime.Value, refund.LastUpDateTime);
                if (!checkTime.Success)
                {
                    return checkTime;
                }
                _mapper.Map(model, refund);
                refund.LastUpDateTime = DateTime.Now;
            }
            returnResult.Obj = await _context.SaveChangesAsync() > 0;
            return returnResult;
        }

        public async Task<bool> EditRefundStatusAsync(int id)
        {
            var refund = await _context.Refunds.FirstOrDefaultAsync(i => i.Id == id && i.RefundStatus == RefundStatusType.NotRefundedYet);
            if (refund != null)
            {
                refund.RefundStatus = RefundStatusType.Refunded;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnPaginSelectDto<ReturnRefundDto>> QueryPaginAsync(SelectRefundDto model)
        {
            var result = new ReturnPaginSelectDto<ReturnRefundDto>();
            var refund = _context.Refunds.Include(i => i.Handler).AsNoTracking();

            switch (model.SelectCondition)
            {
                case "OrderNumber": refund = refund.Where(i => EF.Functions.Like(i.OrderNumber, $"%{model.SelectKeyword}%")); break;
                case "ServiceName": refund = refund.Where(i => EF.Functions.Like(i.ServiceName, $"%{model.SelectKeyword}%")); break;
                case "Product": refund = refund.Where(i => EF.Functions.Like(i.Product, $"%{model.SelectKeyword}%")); break;
                case "*":
                    if (!string.IsNullOrEmpty(model.SelectKeyword))
                    {
                        refund = refund.Where(i => EF.Functions.Like(i.OrderNumber, $"%{model.SelectKeyword}%") ||
                                          EF.Functions.Like(i.ServiceName, $"%{model.SelectKeyword}%") ||
                                          EF.Functions.Like(i.Product, $"%{model.SelectKeyword}%"));
                    }
                    break;
                default:
                    break;
            }

            if (model.RefundStatus.HasValue)
            {
                refund = refund.Where(i => i.RefundStatus == model.RefundStatus);
            }

            if (model.BeginTime.HasValue)
            {
                refund = refund.Where(i => i.RefundTime >= model.BeginTime);
            }

            if (model.EndTime.HasValue)
            {
                refund = refund.Where(i => i.RefundTime <= model.EndTime);
            }

            result.Amount = model.Amount;
            result.Total = await refund.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Items = _mapper.Map<List<ReturnRefundDto>>(await refund.Pagin(model).OrderBy(i => i.CreateTime).ToListAsync());
            return result;
        }
    }
}
