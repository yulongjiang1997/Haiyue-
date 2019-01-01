using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.LeaveAMessages.LeaveAMessageReplys
{
    public class ReturnLeaveAMessageReplyDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
