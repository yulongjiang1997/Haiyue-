using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.Positions
{
    public class ReturnPositionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
