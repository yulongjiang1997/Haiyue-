using Haiyue.Model.Enums;
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
        /// 付款状态
        /// </summary>
        public PaymentStatusType? PaymentStatus { get; set; }
    }
}
