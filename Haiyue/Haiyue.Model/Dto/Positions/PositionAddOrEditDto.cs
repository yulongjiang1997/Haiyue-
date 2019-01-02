using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.Positions
{
    public class PositionAddOrEditDto
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? LastUpDateTime { get; set; }
    }
}
