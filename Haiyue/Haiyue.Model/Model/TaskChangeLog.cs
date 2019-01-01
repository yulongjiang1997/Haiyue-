using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Haiyue.Model.Model
{
    public class TaskChangeLog:BaseModel
    {
        public int TaskId { get; set; }

        /// <summary>
        /// 任务内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 操作人ID
        /// </summary>
        public int OperatorId { get; set; }

        [ForeignKey("OperatorId")]
        public virtual User Operator { get; set; }

        /// <summary>
        /// 任务开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 任务结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
