using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Haiyue.Model.Model
{
    public class TaskList:BaseModel
    {
        /// <summary>
        /// 任务标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 任务内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 发布人ID
        /// </summary>
        public int PublisherId { get; set; }

        /// <summary>
        /// 指派人ID
        /// </summary>
        public int AssignId { get; set; }

        /// <summary>
        /// 任务开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 任务结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 任务当前状态
        /// </summary>
        public TaskStatusType TaskStatus { get; set; }

    }
}
