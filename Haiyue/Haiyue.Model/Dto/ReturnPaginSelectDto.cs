using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto
{
    public class ReturnPaginSelectDto<T>
    {
        public List<T> Items { get; set; }

        public int Total { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int Amount { get; set; }
    }
}
