using AutoMapper;
using Haiyue.HYEF;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.OtherOrders;
using Haiyue.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.OtherOrderServices
{
    public class OtherOrderService : IOtherOrderService
    {
        private readonly HYContext _context;
        private readonly IMapper _mapper;

        public OtherOrderService(HYContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(AddOrEditOtherOrderDto model)
        {
            var otherOrder = _mapper.Map<OtherOrder>(model);
            _context.OtherOrders.Add(otherOrder);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var otherOrder = await _context.OtherOrders.FirstOrDefaultAsync(i => i.Id == id);
            _context.OtherOrders.Remove(otherOrder);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditAsync(int id, AddOrEditOtherOrderDto model)
        {
            var otherOrder = await _context.OtherOrders.FirstOrDefaultAsync(i => i.Id == id);
            if (otherOrder != null)
            {
                _mapper.Map(model, otherOrder);
                otherOrder.LastUpTime = DateTime.Now;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnPaginSelectDto<ReturnOtherOrderDto>> QueryPaginAsync(SelectOtherOrderDto model)
        {
            var result = new ReturnPaginSelectDto<ReturnOtherOrderDto>();
            var otherOrders = _context.OtherOrders.AsNoTracking();

            switch (model.SelectCondition)
            {
                case "OrderNumber": otherOrders = otherOrders.Where(i => EF.Functions.Like(i.OrderNumber, $"{model.SelectKeyword}")); break;
                case "ServiceName": otherOrders.Where(i => EF.Functions.Like(i.ServiceName, $"{model.SelectKeyword}")); break;
                case "*":
                    otherOrders.Where(i => EF.Functions.Like(i.OrderNumber, $"{model.SelectKeyword}") ||
                                      EF.Functions.Like(i.ServiceName, $"{model.SelectKeyword}"));
                    break;
                default:
                    break;
            }

            if (model.PaymentStatus.HasValue)
            {
                otherOrders = otherOrders.Where(i => i.PaymentStatus == model.PaymentStatus);
            }

            result.Amount = model.Amount;
            result.Total = await otherOrders.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Items = _mapper.Map<List<ReturnOtherOrderDto>>(await otherOrders.Pagin(model).OrderBy(i => i.CreateTime).ToListAsync());
            return result;
        }
    }
}
