using Haiyue.Model.Dto.LeaveAMessages.LeaveAMessageReplys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.LeaveAMessages
{
    public class ReturnLeaveAMessageDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime LastUpDateTime { get; set; }

        public List<ReturnLeaveAMessageReplyDto> LeaveAMessageReply { get; set; }
    }
}
