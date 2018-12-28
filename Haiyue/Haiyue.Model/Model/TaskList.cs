using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Model
{
    public class TaskList:BaseModel
    {
        public int PublisherId { get; set; }
        public int AssignId { get; set; }
        public TaskStatusType TaskStatus { get; set; }

    }
}
