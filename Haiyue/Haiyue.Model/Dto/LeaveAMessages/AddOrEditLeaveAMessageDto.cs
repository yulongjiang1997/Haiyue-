using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.LeaveAMessages
{
    public class AddOrEditLeaveAMessageReplyDto
    {
        public int UserId { get; set; }

        public int LeaveAMessageId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
