﻿using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Haiyue.Model.Model
{
    public class TaskStatusLog:BaseModel<int>
    {
        public int TaskId { get; set; }

        /// <summary>
        /// 变更前状态
        /// </summary>
        public TaskStatusType CurrentStatus{get;set;}

        /// <summary>
        /// 变更后状态
        /// </summary>
        public TaskStatusType ChangeStatus { get; set; }
    }
}
