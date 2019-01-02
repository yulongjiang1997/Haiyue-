using AutoMapper;
using Haiyue.HYEF;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Expenditures;
using Haiyue.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.ExpenditureServices
{
    public class ExpenditureService : IExpenditureService
    {
        private readonly HYContext _context;
        private readonly IMapper _mapper;

        public ExpenditureService(HYContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(AddOrEditExpenditureDto model)
        {
            var expenditure = _mapper.Map<Expenditure>(model);
            _context.Expenditures.Add(expenditure);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var expenditure = await _context.Expenditures.FirstOrDefaultAsync(i => i.Id == id);
            _context.Expenditures.Remove(expenditure);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditAsync(int id, AddOrEditExpenditureDto model)
        {
            var expenditure = await _context.Expenditures.FirstOrDefaultAsync(i => i.Id == id);
            if (expenditure != null)
            {
                _mapper.Map(model, expenditure);
                expenditure.LastUpTime = DateTime.Now;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnPaginSelectDto<ReturnExpenditureDto>> QueryPaginAsync(SelectExpenditureDto model)
        {
            var result = new ReturnPaginSelectDto<ReturnExpenditureDto>();
            var expenditure = _context.Expenditures.Include(i => i.ExpenditureType).Include(i => i.User).AsNoTracking();

            if (model.BeginTime.HasValue)
            {
                expenditure = expenditure.Where(i => i.ExpenditureTime >= model.BeginTime);
            }

            if (model.EndTime.HasValue)
            {
                expenditure = expenditure.Where(i => i.ExpenditureTime <= model.EndTime);
            }

            if (model.ExpenditureTypeId.HasValue)
            {
                expenditure = expenditure.Where(i => i.ExpenditureTypeId == model.ExpenditureTypeId);
            }

            switch (model.SelectCondition)
            {
                case "*":
                    if (!string.IsNullOrEmpty(model.SelectKeyword))
                    {
                        expenditure = expenditure.Where(i => EF.Functions.Like(i.Remarks, $"%{model.SelectKeyword}%") ||
                                                             EF.Functions.Like(i.User.Name, $"%{model.SelectKeyword}%"));
                    }
                    break;
                default:
                    break;
            }

            result.Amount = model.Amount;
            result.Total = await expenditure.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Items = _mapper.Map<List<ReturnExpenditureDto>>(await expenditure.Pagin(model).OrderBy(i => i.ExpenditureTime).ToListAsync());
            return result;
        }
    }
}
