using Haiyue.Model.Dto;
using Haiyue.Model.Dto.LeaveAMessages;
using Haiyue.Model.Dto.LeaveAMessages.LeaveAMessageReplys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.LeaveAMessageServices
{
    public interface ILeaveAMessageService
    {
        /// <summary>
        /// 添加留言
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(AddOrEditLeaveAMessageDto model);


        /// <summary>
        /// 添加留言回复
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CreateReplyAsync(AddOrEditLeaveAMessageReplyDto model);

        /// <summary>
        /// 删除留言回复
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteReplyAsync(int id);

        /// <summary>
        /// 删除留言
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑留言
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> EditAsync(int id, Model.Dto.LeaveAMessages.AddOrEditLeaveAMessageDto model);

        /// <summary>
        /// 分页查询留言
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPaginSelectDto<ReturnLeaveAMessageDto>> QueryPaginAsync(SelectLeaveAMessageDto model);
    }
}
