using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.Refunds
{
    public class SelectRefundDto:SelectBaseDto
    {
       public RefundStatusType? RefundStatus { get; set; }
    }
}
