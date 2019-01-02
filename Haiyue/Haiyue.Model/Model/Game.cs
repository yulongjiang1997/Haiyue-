using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Model
{
    public class Game:BaseModel<int>
    {
        public string Name { get; set; }
        
        /// <summary>
        /// 订单导航
        /// </summary>
        public  ICollection<Purchase> Purchase { get; set; }
    }
}
