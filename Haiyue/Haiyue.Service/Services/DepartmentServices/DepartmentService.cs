using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Haiyue.HYEF;
using Haiyue.Model;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Departments;
using Haiyue.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Haiyue.Service.Services.DepartmentServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HYContext _context;
        private readonly IMapper _mapper;

        public DepartmentService(HYContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReturnData<bool>> CreateAsync(DepartmentAddOrEditDto model)
        {
            var returnResult = new ReturnData<bool>();
            if (!await CheckOnly(model.Name))
            {
                returnResult.Message = "部门名称重复，修改失败";
                returnResult.Obj = false;
                returnResult.Success = false;
                return returnResult;
            }
            var department = _mapper.Map<Department>(model);
            _context.Department.Add(department);
            returnResult.Obj = await _context.SaveChangesAsync() > 0;
            return returnResult;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var department = await _context.Department.FirstOrDefaultAsync(i => i.Id == id);
            if (department != null)
            {
                _context.Department.Remove(department);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnData<bool>> EditAsync(int id, DepartmentAddOrEditDto model)
        {
            var returnResult = new ReturnData<bool>();
            var department = await _context.Department.FirstOrDefaultAsync(i => i.Id == id);
            if (department != null)
            {
                var checkTime = CheckLastUpDateTime.Check(model.LastUpDateTime.Value, department.LastUpDateTime);
                if (!checkTime.Success)
                {
                    return checkTime;
                }
                if(! await CheckOnly(model.Name,id))
                {
                    returnResult.Message = "部门名称重复，修改失败";
                    returnResult.Obj = false;
                    returnResult.Success = false;
                    return returnResult;
                }
                _mapper.Map(model, department);
                department.LastUpDateTime = DateTime.Now;
            }
            returnResult.Obj = await _context.SaveChangesAsync() > 0;
            return returnResult;
        }

        public async Task<ReturnPaginSelectDto<ReturnDepartmentDto>> QueryPaginAsync(SelectDepartmentDto model)
        {
            var result = new ReturnPaginSelectDto<ReturnDepartmentDto>();
            var departments = _context.NoteBooks.AsNoTracking();
            result.Amount = model.Amount;
            result.Total = await departments.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Items = _mapper.Map<List<ReturnDepartmentDto>>(await departments.Pagin(model).OrderBy(i => i.CreateTime).ToListAsync());
            return result;
        }

        /// <summary>
        /// 检查重复名称
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> CheckOnly(string name, int? id = null)
        {
            var department = new Department();
            if (id.HasValue)
            {
                department = await _context.Department.FirstOrDefaultAsync(i => i.Id != id && i.Name == name);
            }
            else
            {
                department = await _context.Department.FirstOrDefaultAsync(i => i.Name == name);
            }
            return department == null;
        }
    }
}
