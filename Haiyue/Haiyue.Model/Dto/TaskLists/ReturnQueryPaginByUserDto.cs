using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.TaskLists
{
    public class ReturnQueryPaginByUserDto
    {
        public ReturnPaginSelectDto<ReturnTaskListDto> MyReleaseTask { get; set; }

        public ReturnPaginSelectDto<ReturnTaskListDto> SendToMeTask { get; set; }
    }
}
