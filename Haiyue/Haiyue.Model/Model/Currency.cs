using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Model
{
    public class Currency:BaseModel
    {
        public string Name { get; set; }

        public string Symbol { get; set; }

        public double ExchangeRate { get; set; }
       
    }
}
