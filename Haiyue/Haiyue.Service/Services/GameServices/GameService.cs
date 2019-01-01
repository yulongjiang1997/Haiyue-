using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Haiyue.HYEF;
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
        public async Task<bool> CreateAsync(GameAddOrEditDto model)
        {
            var game = _mapper.Map<Game>(model);
            _context.Games.Add(game);
            return await _context.SaveChangesAsync() > 0;
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

        public async Task<bool> EditAsync(int id, GameAddOrEditDto model)
        {
            var game = await _context.Games.FirstOrDefaultAsync(i => i.Id == id);
            if (game != null)
            {
                _mapper.Map(model, game);
                game.LastUpTime = DateTime.Now;
            }
            return await _context.SaveChangesAsync() > 0;
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
            result.Items =_mapper.Map<List<ReturnGameDto>>(await games.Pagin(model).OrderBy(i => i.CreateTime).ToListAsync());
            return result;
        }
    }
}
