using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.LeaveAMessages
{
    public class AddOrEditLeaveAMessageDto
    {
        public int UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
