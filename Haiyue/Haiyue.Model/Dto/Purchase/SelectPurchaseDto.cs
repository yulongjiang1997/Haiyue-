using EPMS.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.Purchase
{
    public class SelectPurchaseDto:SelectBaseDto
    {
        /// <summary>
        /// 游戏ID
        /// </summary>
        public int? GameId { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// 服务器名称
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// 供应商联系方式
        /// </summary>
        public string SupplierPhone { get; set; }

        /// <summary>
        /// 付款状态
        /// </summary>
        public PaymentStatusType? PaymentStatus { get; set; }
    }
}
