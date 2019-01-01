using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Haiyue.Model.Model
{
    public class LeaveAMessage:BaseModel
    {
        public int UserId { get; set; }

        //[ForeignKey("UserId")]
        //public virtual User User { get; set; }
 
        public string Title { get; set; }

        public string Content { get; set; }

        public ICollection<LeaveAMessageReply> LeaveAMessageReply { get; set; }
    }
}
