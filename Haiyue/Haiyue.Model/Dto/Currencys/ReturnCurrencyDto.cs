using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.Currencys
{
    public class ReturnCurrencyDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public double ExchangeRate { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
