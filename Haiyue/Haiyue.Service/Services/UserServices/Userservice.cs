using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Haiyue.Model.Enums;
using Haiyue.HYEF;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Users;
using Haiyue.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Haiyue.Service.Services.UserServices
{
    public class Userservice : IUserservice
    {
        private readonly HYContext _context;
        private readonly IMapper _mapper;

        public Userservice(HYContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> CreateAsync(UserAddOrEditDto model)
        {
            if (await ChekeUserOnly(model.Name, model.IdNumber))
            {
                var user = _mapper.Map<User>(model);
                user.PassWored = MD5Help.MD5Encrypt32(user.PassWored);
                _context.Users.Add(user);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditAsync(int id, UserAddOrEditDto model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Id == id);
            if (user != null && await ChekeUserOnly(model.Name, model.IdNumber, id))
            {
               _mapper.Map(model,user);
                user.PassWored = MD5Help.MD5Encrypt32(user.PassWored);
                user.LastUpTime = DateTime.Now;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public List<ReturnJurisdictionTypeDto> GetJurisdictionType()
        {
            var result = new List<ReturnJurisdictionTypeDto>();
            foreach (var item in Enum.GetValues(typeof(JurisdictionType)))
            {
                result.Add(new ReturnJurisdictionTypeDto() { Id = (int)item, Name = item.ToString() });
            }
            return result;
        }

        public async Task<ReturnPaginSelectDto<ReturnUserDto>> QueryPaginAsync(SelectUserDto model)
        {
            var result = new ReturnPaginSelectDto<ReturnUserDto>();
            var user = (from u in _context.Users
                        join p in _context.Positions on u.PositionId equals p.Id
                        select new ReturnUserDto
                        {
                            Education = u.Education,
                            EntryTime = u.EntryTime,
                            IdNumber = u.IdNumber,
                            IncumbencyStatus = u.IncumbencyStatus,
                            JobNumber = u.JobNumber,
                            Jurisdiction = u.Jurisdiction,
                            LoginTime = u.LoginTime,
                            Name = u.Name,
                            Phone = u.Phone,
                            Position = p.Name,
                            RegisteredResidence = u.RegisteredResidence,
                            Remarks = u.Remarks,
                            CreateTime = u.CreateTime
                        }).AsQueryable();
            result.Amount = model.Amount;
            result.Total = await user.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Items = await user.Pagin(model).OrderBy(i => i.CreateTime).ToListAsync();
            return result;
        }

        public async Task<bool> ChekeUserOnly(string name, string idNumber, int? editId = null)
        {
            User user = new User();
            if (editId.HasValue)
            {
                user = await _context.Users.FirstOrDefaultAsync(i => i.Name == name && i.IdNumber == idNumber && i.Id != editId);
            }
            else
            {
                user = await _context.Users.FirstOrDefaultAsync(i => i.Name == name && i.IdNumber == idNumber);
            }

            return user == null;
        }
    }
}
