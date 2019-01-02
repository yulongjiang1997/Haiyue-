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
using Haiyue.Model;

namespace Haiyue.Service.Services.UserServices
{
    public class Userservice : IUserservice
    {
        //创建ef实体
        private readonly HYContext _context;
        //创基AutoMapper实体
        private readonly IMapper _mapper;

        public Userservice(HYContext context, IMapper mapper)
        {
            //使用构造器注入实体
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 添加User
        /// </summary>
        /// <param name="model">添加用户需要的实体</param>
        /// <returns></returns>
        public async Task<bool> CreateUserAsync(UserAddOrEditDto model)
        {
            //检查用户是否重复
            if (await ChekeUserOnly(model.IdNumber))
            {
                //使用AutoMapper自动映射添加用户实体的数据到数据库所需实体
                var user = _mapper.Map<User>(model);
                //密码使用MD5加密
                user.Password = MD5Help.MD5Encrypt32(user.Password);
                _context.Users.Add(user);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 根据id删除用户
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 根据id编辑用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ReturnData<bool>> EditUserByIdAsync(int id, UserAddOrEditDto model)
        {
            var returnResult = new ReturnData<bool>();
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Id == id);
            //检查当前id是否有对应用户
            if (user != null)
            {
                var checkTime = CheckLastUpDateTime.Check(model.LastUpDateTime.Value, user.LastUpDateTime);
                if (!checkTime.Success)
                {
                    return checkTime;
                }
                if(!await ChekeUserOnly(model.IdNumber,id))
                {
                    returnResult.Message = "证件号重复，修改失败";
                    returnResult.Obj = false;
                    returnResult.Success = false;
                    return returnResult;
                }
                //使用AutoMapper自动映射数据
                _mapper.Map(model, user);
                //把明文密码转换成密文（md5加密）
                user.Password = MD5Help.MD5Encrypt32(user.Password);
                //修改更新时间
                user.LastUpDateTime = DateTime.Now;
            }
            returnResult.Obj = await _context.SaveChangesAsync() > 0;
            return returnResult;
        }

        /// <summary>
        /// 获得权限类型
        /// </summary>
        /// <returns></returns>
        public List<ReturnJurisdictionTypeDto> GetJurisdictionType()
        {
            var result = new List<ReturnJurisdictionTypeDto>();
            foreach (var item in Enum.GetValues(typeof(JurisdictionType)))
            {
                result.Add(new ReturnJurisdictionTypeDto() { Id = (int)item, Name = item.ToString() });
            }
            return result;
        }

        /// <summary>
        /// 分页查询用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 检查用户是否重复，
        /// 根据身份证进行检查
        /// </summary>
        /// <param name="idNumber">身份证</param>
        /// <param name="editId">编辑使用的用户id 添加用户不使用</param>
        /// <returns></returns>
        private async Task<bool> ChekeUserOnly(string idNumber, int? editId = null)
        {
            User user = new User();
            if (editId.HasValue)
            {
                //如果编辑用户的Id不为空 那么检查id不为当前id的用户是否有重复信息
                user = await _context.Users.FirstOrDefaultAsync(i =>i.IdNumber == idNumber && i.Id != editId);
            }
            else
            {
                user = await _context.Users.FirstOrDefaultAsync(i =>i.IdNumber == idNumber);
            }

            return user == null;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model">登录需要的数据实体</param>
        /// <returns></returns>
        public async Task<ReturnLoginDto> Login(LoginDto model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Name == model.UserName && i.Password == MD5Help.MD5Encrypt32(model.Password));
            ReturnLoginDto result = null;
            //检查查询出来是否有匹配的用户，有匹配的则登录成功
            if (user != null)
            {
                //更新登录信息
                var loginInfo = await UpdateLoginInfo(user);

                //实例化一个登录成功的返回信息
                result = new ReturnLoginDto()
                {
                    Jurisdiction = loginInfo.User.Jurisdiction,
                    Name = loginInfo.User.Name,
                    OutTime = loginInfo.OutTime,
                    Token = loginInfo.Token,
                    UserId = loginInfo.UserId
                };
                //修改登录时间
                user.LoginTime = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return result == null ? null : result;
        }

        public async Task<LoginInfo> UpdateLoginInfo(User user)
        {
            //查询当前用户的登录信息
            var loginInfo = await _context.LoginInfos.FirstOrDefaultAsync(i => i.UserId == user.Id);

            //实例化登录信息的实体
            var result = new LoginInfo()
            {
                LastUpDateTime = DateTime.Now,
                OutTime = DateTime.Now.AddMinutes(30),
                Token = MD5Help.MD5Encrypt32(user.IdNumber + user.JobNumber + DateTime.Now),
                UserId = user.Id
            };
            //判断数据库是否有该用户的信息，有则更新，没有则新加
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

        public bool CheckTokenTimeOut(int userId, string token)
        {
            var timeOut = _context.LoginInfos.FirstOrDefault(i => i.UserId == userId && i.Token == token && i.OutTime > DateTime.Now);
            return timeOut != null;
        }

        public bool CheckIsAdmin(int userId)
        {
            var timeOut = _context.LoginInfos.FirstOrDefault(i => i.UserId == userId && i.User.Jurisdiction == JurisdictionType.SuperAdmin);
            return timeOut != null;
        }
    }
}
