using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.TaskLists
{
    public class SelectTaskListDto : SelectBaseDto
    {
        public TaskDelegationType? TaskDelegationType { get; set; }
        public string UserId { get; set; }
        public TaskStatusType? TaskStatusType { get; set; }
    }
}
