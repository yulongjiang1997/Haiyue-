using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.Expenditures
{
    public class AddOrEditExpenditureDto
    {
        /// <summary>
        /// 支出日期
        /// </summary>
        public DateTime ExpenditureTime { get; set; }

        /// <summary>
        /// 支出类型ID
        /// </summary>
        public int ExpenditureTypeId { get; set; }

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
