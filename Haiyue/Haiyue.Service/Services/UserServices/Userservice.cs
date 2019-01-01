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
using Haiyue.Model.Dto.Admin;

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
                user.Password = MD5Help.MD5Encrypt32(user.Password);
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
                _mapper.Map(model, user);
                user.Password = MD5Help.MD5Encrypt32(user.Password);
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
            var user = _context.Users.Include(i => i.Position).AsNoTracking();
            result.Amount = model.Amount;
            result.Total = await user.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Items = _mapper.Map<List<ReturnUserDto>>(await user.Pagin(model).OrderBy(i => i.CreateTime).ToListAsync());
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

        public async Task<ReturnLoginDto> Login(LoginDto model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Name == model.UserName && i.Password == MD5Help.MD5Encrypt32(model.Password));
            ReturnLoginDto result = null;
            if (user != null)
            {
                var loginInfo = await UpdateLoginInfo(user);
                result = new ReturnLoginDto()
                {
                    Jurisdiction = loginInfo.User.Jurisdiction,
                    Name = loginInfo.User.Name,
                    OutTime = loginInfo.OutTime,
                    Token = loginInfo.Token,
                    UserId = loginInfo.UserId
                };
                user.LoginTime = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return result == null ? null : result;
        }

        public async Task<LoginInfo> UpdateLoginInfo(User user)
        {
            var loginInfo = await _context.LoginInfos.FirstOrDefaultAsync(i => i.UserId == user.Id);
            var result = new LoginInfo()
            {
                LastUpTime = DateTime.Now,
                OutTime = DateTime.Now.AddMinutes(30),
                Token = MD5Help.MD5Encrypt32(user.IdNumber + user.JobNumber + DateTime.Now),
                UserId = user.Id
            };
            if (loginInfo != null)
            {
                loginInfo = result;
            }
            else
            {
                _context.LoginInfos.Add(result);
            }
            await _context.SaveChangesAsync();
            return result;
        }

        public  bool CheckTokenTimeOut(int userId, string token)
        {
            var timeOut =  _context.LoginInfos.FirstOrDefault(i => i.UserId == userId && i.Token == token && i.OutTime > DateTime.Now);
            return timeOut != null;
        }

        public bool CheckIsAdmin(int userId)
        {
            var timeOut = _context.LoginInfos.FirstOrDefault(i => i.UserId == userId&&i.User.Jurisdiction==JurisdictionType.SuperAdmin);
            return timeOut != null;
        }
    }
}
