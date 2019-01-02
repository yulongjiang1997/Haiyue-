using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.Departments
{
    public class DepartmentAddOrEditDto
    {
        public string Name { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? LastUpDateTime { get; set; }
    }
}
