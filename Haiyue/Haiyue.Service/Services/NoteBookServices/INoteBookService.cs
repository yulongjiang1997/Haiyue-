using Haiyue.Model.Dto;
using Haiyue.Model.Dto.NoteBooks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.NoteBookServices
{
    public interface INoteBookService
    {
        /// <summary>
        /// 添加记事本内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(NoteBookAddOrEditDto model);

        /// <summary>
        /// 删除记事本内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑记事本内容
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> EditAsync(int id, NoteBookAddOrEditDto model);

        /// <summary>
        /// 分页查询记事本内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPaginSelectDto<ReturnNoteBookDto>> QueryPaginAsync(SelectNoteBoolDto model);
    }
}
