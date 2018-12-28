using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Haiyue.Model.Model
{
    public class Expenditure : BaseModel
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
        /// 操作人
        /// </summary>
        public int HandlerId { get; set; }

        [ForeignKey("HandlerId")]
        public User User { get; set; }

        /// <summary>
        /// 支出金额
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        [ForeignKey("ExpenditureTypeId")]
        public ExpenditureType ExpenditureType { get; set; }
    }
}
