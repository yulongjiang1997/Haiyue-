using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.Expenditures
{
    public class ReturnExpenditureDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 支出日期
        /// </summary>
        public DateTime ExpenditureTime { get; set; }

        /// <summary>
        /// 支出类型
        /// </summary>
        public string ExpenditureType { get; set; }

        /// <summary>
        /// 支出金额
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
