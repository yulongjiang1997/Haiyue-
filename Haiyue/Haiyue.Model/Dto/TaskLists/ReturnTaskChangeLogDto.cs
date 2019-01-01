using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.TaskLists
{
    public class ReturnTaskChangeLogDto
    {
        /// <summary>
        /// 任务内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime EditTime { get; set; }

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
