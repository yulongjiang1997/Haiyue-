using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haiyue.EF;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Currencys;
using Haiyue.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Haiyue.Service.Services.CurrencyServices
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HYContext _context;

        public CurrencyService(HYContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(CurrencyAddOrEditDto model)
        {
            if (await CheckOnly(model.Name))
            {
                _context.Currencys.Add(new Currency()
                {
                    Name = model.Name,
                    Symbol = model.Symbol,
                    ExchangeRate = model.ExchangeRate,
                });
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _context.Currencys.FirstOrDefaultAsync(i => i.Id == id);
            if (result != null)
            {
                _context.Currencys.Remove(result);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditAsync(int id, double exchangeRate)
        {
            var result = await _context.Currencys.FirstOrDefaultAsync(i => i.Id == id);
            if (result != null)
            {
                result.ExchangeRate = exchangeRate;
                result.LastUpTime = DateTime.Now;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<ReturnPaginSelectDto<ReturnCurrencyDto>> QueryPaginAsync(SelectCurrencyDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckOnly(string name, int? id = null)
        {
            Currency result = null;

            if (id.HasValue)
            {
                result = await _context.Currencys.FirstOrDefaultAsync(i => i.Name == name && i.Id != id);
            }
            else
            {
                result = await _context.Currencys.FirstOrDefaultAsync(i => i.Name == name);
            }
            return result == null;
        }

        public async Task<List<ReturnQueryAllDto>> QueryAllAsync()
        {
            var result = _context.Currencys.AsNoTracking().Select(i => new ReturnQueryAllDto() { Id = i.Id, Name = i.Name });
            return await result.ToListAsync();
        }
    }
}
