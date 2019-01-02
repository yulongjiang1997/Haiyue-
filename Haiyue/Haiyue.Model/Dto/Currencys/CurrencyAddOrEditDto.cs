using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.Currencys
{
    public class CurrencyAddOrEditDto
    {
        public string Name { get; set; }

        public string Symbol { get; set; }

        public double ExchangeRate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? LastUpDateTime { get; set; }
    }
}
