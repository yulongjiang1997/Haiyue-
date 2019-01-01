using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.LeaveAMessages.LeaveAMessageReplys
{
    public class AddOrEditLeaveAMessageReplyDto
    {
        /// <summary>
        /// 留言ID
        /// </summary>
        public int LeaveAMessageId { get; set; }

        /// <summary>
        /// 回复用户ID
        /// </summary>
        public int ReplyUserId { get; set; }

        public string Content { get; set; }
    }
}
