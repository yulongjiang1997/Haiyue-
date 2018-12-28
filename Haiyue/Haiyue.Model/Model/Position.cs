using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Haiyue.Model.Model
{
    /// <summary>
    /// 职位
    /// </summary>
    public class Position:BaseModel
    {
        [StringLength(50)]
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        /// <summary>
        /// 员工信息导航
        /// </summary>
        public virtual ICollection<User> User { get; set; }
    }
}