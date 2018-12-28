using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto
{
    public class SelectBaseDto
    {

        public DateTime? BeginTime { get; set; }

        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 第几页
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int Amount { get; set; }
    }
}
