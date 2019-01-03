using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Haiyue.HYEF;
using Haiyue.Model;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Game;
using Haiyue.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Haiyue.Service.Services.GameServices
{
    public class GameService : IGameService
    {
        private readonly HYContext _context;
        private readonly IMapper _mapper;

        public GameService(HYContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReturnData<bool>> CreateAsync(GameAddOrEditDto model)
        {
            var returnResult = new ReturnData<bool>();
            if (!await CheckName(model.Name))
            {
                returnResult.Message = "游戏名不能重复，请确认信息是否正确";
                returnResult.Success = false;
                returnResult.Obj = false;
                return returnResult;
                
            }
            var game = _mapper.Map<Game>(model);
            game.LastUpDateTime = DateTime.Now;
            _context.Games.Add(game);
            returnResult.Obj = await _context.SaveChangesAsync() > 0;
            return returnResult;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(i => i.Id == id);
            if (game != null)
            {
                _context.Games.Remove(game);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnData<bool>> EditAsync(int id, GameAddOrEditDto model)
        {
            var returnResult = new ReturnData<bool>();
            var game = await _context.Games.FirstOrDefaultAsync(i => i.Id == id);
            if (game != null)
            {
                var checkTime = CheckLastUpDateTime.Check(model.LastUpDateTime.Value, game.LastUpDateTime);
                if (!checkTime.Success)
                {
                    return checkTime;
                }
                if (!await CheckName(model.Name, id))
                {
                    returnResult.Message = "游戏名不能重复，请确认信息是否正确";
                    returnResult.Success = false;
                    returnResult.Obj = false;
                    return returnResult;
                }
                _mapper.Map(model, game);
                game.LastUpDateTime = DateTime.Now;
            }
            returnResult.Obj = await _context.SaveChangesAsync() > 0;
            return returnResult;
        }

        public async Task<List<ReturnGameDto>> QueryAll()
        {
            var games = _context.Games.AsNoTracking();
            return _mapper.Map<List<ReturnGameDto>>(await games.ToListAsync());
        }

        public async Task<ReturnPaginSelectDto<ReturnGameDto>> QueryPaginAsync(SelectGameDto model)
        {
            var result = new ReturnPaginSelectDto<ReturnGameDto>();
            var games = _context.Games.AsNoTracking();
            result.Total = await games.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Amount = model.Amount;
            result.Items = _mapper.Map<List<ReturnGameDto>>(await games.Pagin(model).OrderBy(i => i.CreateTime).ToListAsync());
            return result;
        }

        public async Task<bool> CheckName(string name, int? id = null)
        {
            Game game = null;
            if (id == null)
            {
                game = await _context.Games.FirstOrDefaultAsync(i => i.Name == name);
            }
            else
            {
                game = await _context.Games.FirstOrDefaultAsync(i => i.Name == name && i.Id != id);
            }
            return game == null;
        }
    }
}
