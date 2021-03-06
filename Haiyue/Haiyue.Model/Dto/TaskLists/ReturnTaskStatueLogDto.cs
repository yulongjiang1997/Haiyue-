﻿using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.TaskLists
{
    public class ReturnTaskStatueLogDto
    {
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime EditTime { get; set; }

        /// <summary>
        /// 变更前状态
        /// </summary>
        public TaskStatusType CurrentStatus { get; set; }

        /// <summary>
        /// 变更后状态
        /// </summary>
        public TaskStatusType ChangeStatus { get; set; }
    }
}
