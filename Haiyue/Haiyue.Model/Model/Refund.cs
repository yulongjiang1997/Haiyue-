using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Haiyue.Model.Model
{
    public class Refund : BaseModel<int>
    {
        /// <summary>
        /// 退款时间
        /// </summary>
        public DateTime RefundTime { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// 服务器名称
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 游戏或者礼品卡
        /// </summary>
        public string GmaeOrGiftCard { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// 实际付款
        /// </summary>
        public double ActualPayment { get; set; }

        /// <summary>
        /// 实际退款
        /// </summary>
        public double ActualRefund { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        public double RefundAmount { get; set; }

        /// <summary>
        /// 退款状态
        /// </summary>
        public RefundStatusType RefundStatus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string HandlerId { get; set; }

        [ForeignKey("HandlerId")]
        public User Handler { get; set; }

    }
}
