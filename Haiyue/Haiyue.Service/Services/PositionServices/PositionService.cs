using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Haiyue.HYEF;
using Haiyue.Model;
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

        public async Task<ReturnData<bool>> CreateAsync(PositionAddOrEditDto model)
        {
            var returnResult = new ReturnData<bool>();
            if (!await CheckOnly(model.Name))
            {
                returnResult.Message = "职位名称重复，修改失败";
                returnResult.Obj = false;
                returnResult.Success = false;
                return returnResult;
            }
            var position = _mapper.Map<Position>(model);
            _context.Positions.Add(position);
            returnResult.Obj = await _context.SaveChangesAsync() > 0;
            return returnResult;
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

        public async Task<ReturnData<bool>> EditAsync(int id, PositionAddOrEditDto model)
        {
            var returnResult = new ReturnData<bool>();
            var position = await _context.Positions.FirstOrDefaultAsync(i => i.Id == id);
            if (position != null)
            {
                var checkTime = CheckLastUpDateTime.Check(model.LastUpDateTime.Value, position.LastUpDateTime);
                if (!checkTime.Success)
                {
                    return checkTime;
                }
                if(! await CheckOnly(model.Name,id))
                {
                    returnResult.Message = "职位名称重复，修改失败";
                    returnResult.Obj = false;
                    returnResult.Success = false;
                    return returnResult;
                }
                _mapper.Map(model, position);
                position.LastUpDateTime = DateTime.Now;
            }
            returnResult.Obj = await _context.SaveChangesAsync() > 0;
            return returnResult;
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
