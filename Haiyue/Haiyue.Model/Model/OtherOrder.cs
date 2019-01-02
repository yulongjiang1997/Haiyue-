using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Haiyue.Model.Model
{
    public class OtherOrder : BaseModel<int>
    {

        /// <summary>
        /// 订单时间
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string HandlerId { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// 服务器名称
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 支出总价
        /// </summary>
        public string TotalExpenditure { get; set; }

        /// <summary>
        /// 付款状态
        /// </summary>
        public PaymentStatusType PaymentStatus { get; set; }

        /// <summary>
        /// 实际付款
        /// </summary>
        public double ActualPayment { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        [ForeignKey("HandlerId")]
        public User Handler { get; set; }
    }
}
