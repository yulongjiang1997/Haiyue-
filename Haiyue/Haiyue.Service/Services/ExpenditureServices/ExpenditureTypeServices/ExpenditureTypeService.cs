using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Haiyue.HYEF;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Expenditures.ExpenditureTypes;
using Haiyue.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Haiyue.Service.Services.ExpenditureServices.ExpenditureTypeServices
{
    public class ExpenditureTypeService : IExpenditureTypeService
    {
        private readonly HYContext _context;
        private readonly IMapper _mapper;

        public ExpenditureTypeService(HYContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(AddOrEditExpeditureTypeDto model)
        {
            var expenditureType = _mapper.Map<ExpenditureType>(model);
            _context.ExpenditureTypes.Add(expenditureType);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var expenditureType = await _context.ExpenditureTypes.FirstOrDefaultAsync(i => i.Id == id);
            _context.ExpenditureTypes.Remove(expenditureType);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnPaginSelectDto<ReturnExpeditureTypeDto>> QueryPaginAsync(SelectExpeditureTypeDto model)
        {
            var result = new ReturnPaginSelectDto<ReturnExpeditureTypeDto>();
            var expenditureType = _context.ExpenditureTypes.AsNoTracking();
            result.Amount = model.Amount;
            result.Total = await expenditureType.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Items = _mapper.Map<List<ReturnExpeditureTypeDto>>(await expenditureType.Pagin(model).OrderBy(i => i.CreateTime).ToListAsync());
            return result;
        }
    }
}
