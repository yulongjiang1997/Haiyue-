using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Haiyue.Model.Model
{
    public class LeaveAMessageReply : BaseModel<int>
    {
        /// <summary>
        /// 留言ID
        /// </summary>
        public int LeaveAMessageId { get; set; }

        [ForeignKey("LeaveAMessageId")]
        public virtual LeaveAMessage LeaveAMessage { get; set; }

        /// <summary>
        /// 回复用户ID
        /// </summary>
        public string ReplyUserId { get; set; }

        [ForeignKey("ReplyUserId")]
        public virtual User ReplyUser { get; set; }

        public string Content { get; set; }
    }
}
