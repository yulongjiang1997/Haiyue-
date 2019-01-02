using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Haiyue.HYEF;
using Haiyue.Model;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Currencys;
using Haiyue.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Haiyue.Service.Services.CurrencyServices
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HYContext _context;
        private readonly IMapper _mapper;

        public CurrencyService(HYContext context, IMapper mapper)
        {
            //通过依赖注入 注入context和automapper对象
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(CurrencyAddOrEditDto model)
        {
            //检查货币名是否重复
            if (await CheckOnly(model.Name))
            {
                //通过automapper对象自动转换Dto为Model实体
                var currencys = _mapper.Map<Currency>(model);
                _context.Currencys.Add(currencys);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            //根据ID查询对象判断是否为空  不为空则删除
            var result = await _context.Currencys.FirstOrDefaultAsync(i => i.Id == id);
            if (result != null)
            {
                _context.Currencys.Remove(result);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnData<bool>> EditAsync(int id, CurrencyAddOrEditDto model)
        {
            var returnResult = new ReturnData<bool>();
            //根据ID查询对象判断是否为空  不为空则修改
            var result = await _context.Currencys.FirstOrDefaultAsync(i => i.Id == id);
            if (result != null)
            {
                var checkTime = CheckLastUpDateTime.Check(model.LastUpDateTime.Value, result.LastUpDateTime);
                if (!checkTime.Success)
                {
                    return checkTime;
                }
                if (!await CheckOnly(model.Name,id))
                {
                    returnResult.Message = "汇率名称重复，修改失败";
                    returnResult.Obj = false;
                    returnResult.Success = false;
                    return returnResult;
                }
                result.ExchangeRate = model.ExchangeRate;
                result.LastUpDateTime = DateTime.Now;
            }
            returnResult.Obj = await _context.SaveChangesAsync() > 0;
            return returnResult;
        }

        public async Task<ReturnPaginSelectDto<ReturnCurrencyDto>> QueryPaginAsync(SelectCurrencyDto model)
        {
            var result = new ReturnPaginSelectDto<ReturnCurrencyDto>();
            var currency = _context.Currencys.AsNoTracking();

            result.Total = await currency.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Amount = model.Amount;
            //通过AutoMapper对象转换成返回的实体
            result.Items = _mapper.Map<List<ReturnCurrencyDto>>(await currency.Pagin(model).OrderBy(i => i.CreateTime).ToListAsync());

            return result;
        }

        public async Task<bool> CheckOnly(string name, int? id = null)
        {
            Currency result = null;

            //检查id有值表示为正在修改数据，则检查名称是否重复 且不是本条数据
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
            //查询数据 通过AutoMapper对象转换成List<ReturnQueryAllDto>对象返回
            var result = _context.Currencys.AsNoTracking();

            return _mapper.Map<List<ReturnQueryAllDto>>(await result.ToListAsync());
        }
    }
}
