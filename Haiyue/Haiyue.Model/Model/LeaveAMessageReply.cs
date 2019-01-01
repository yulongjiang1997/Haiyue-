using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Haiyue.Model.Model
{
    public class LeaveAMessageReply : BaseModel
    {
        /// <summary>
        /// 留言ID
        /// </summary>
        public int LeaveAMessageId { get; set; }

        [ForeignKey("LeaveAMessageId")]
        public LeaveAMessage LeaveAMessage { get; set; }

        /// <summary>
        /// 回复用户ID
        /// </summary>
        public int ReplyUserId { get; set; }

        [ForeignKey("ReplyUserId")]
        public User ReplyUser { get; set; }

        public string Content { get; set; }
    }
}
