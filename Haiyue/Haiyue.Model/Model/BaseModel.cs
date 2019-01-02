using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Haiyue.Model.Model
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public DateTime CreateTime { get; set; }
        [StringLength(30)]
        public DateTime LastUpDateTime { get; set; }

        public BaseModel()
        {
            CreateTime = DateTime.Now;
            LastUpDateTime = DateTime.Now;
        }
    }
}
