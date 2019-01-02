using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.Game
{
    public class ReturnGameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime LastUpDateTime { get; set; }
    }
}
