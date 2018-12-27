using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Haiyue.HYEF;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Positions;
using Haiyue.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Haiyue.Service.Services.PositionServices
{
    public class PositionService : IPositionService
    {
        private readonly HYContext _context;

        private readonly IMapper _mapper;
        public PositionService(HYContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(PositionAddOrEditDto model)
        {
            if (await CheckOnly(model.Name))
            {
                var position = _mapper.Map<Position>(model);
                _context.Positions.Add(position);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _context.Positions.FirstOrDefaultAsync(i => i.Id == id);
            if (result != null)
            {
                _context.Positions.Remove(result);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditAsync(int id, PositionAddOrEditDto model)
        {
            var position = await _context.Positions.FirstOrDefaultAsync(i => i.Id == id);
            if (position != null && await CheckOnly(model.Name, id))
            {
                _mapper.Map(model, position);
                position.LastUpTime = DateTime.Now;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnPaginSelectDto<ReturnPositionDto>> QueryPaginAsync(SelectPositionDto model)
        {
            var result = new ReturnPaginSelectDto<ReturnPositionDto>();
            var position = _context.Positions.AsNoTracking();
            result.Total = await position.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Amount = model.Amount;
            result.Items =_mapper.Map<List<ReturnPositionDto>>(await position.Pagin(model).OrderBy(i => i.CreateTime).ToListAsync());

            return result;
        }

        public async Task<bool> CheckOnly(string name, int? id = null)
        {
            var position = new Position();
            if (id.HasValue)
            {
                position = await _context.Positions.FirstOrDefaultAsync(i => i.Name == name && i.Id != id);
            }
            else
            {
                position = await _context.Positions.FirstOrDefaultAsync(i => i.Name == name);
            }
            return position == null;
        }
    }
}
