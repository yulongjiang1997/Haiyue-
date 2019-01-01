using Haiyue.Model.Enums;
using Haiyue.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.TaskLists
{
    public class ReturnTaskListDto
    {
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 任务标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 任务内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 发布人
        /// </summary>
        public string PublisherName { get; set; }

        /// <summary>
        /// 指派人
        /// </summary>
        public string AssignName { get; set; }

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

        public List<ReturnTaskStatueLogDto> TaskStatusLogs { get; set; }

        public List<ReturnTaskChangeLogDto> TaskChangeLogs { get; set; }
    }
}
