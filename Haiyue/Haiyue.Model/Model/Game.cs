using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Model
{
    public class Game:BaseModel
    {
        public string Name { get; set; }

        /// <summary>
        /// 采购导航
        /// </summary>
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
