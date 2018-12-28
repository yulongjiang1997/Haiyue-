﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Haiyue.Model.Model
{
    /// <summary>
    /// 部门
    /// </summary>
    public class Department:BaseModel
    {
        [StringLength(50)]
        public string Name { get; set; }


        public ICollection<Position> Positions { get; set; }
    }
}
