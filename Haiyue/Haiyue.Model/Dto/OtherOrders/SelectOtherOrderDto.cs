using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.OtherOrders
{
    public class SelectOtherOrderDto:SelectBaseDto
    {
        public PaymentStatusType? PaymentStatus { get; set; }
    }
}
