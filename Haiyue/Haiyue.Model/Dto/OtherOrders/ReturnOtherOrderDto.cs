﻿using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.OtherOrders
{
    public class ReturnOtherOrderDto
    {
        public int Id { get; set; }

        /// <summary>
        /// 订单时间
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string Handler { get; set; }

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

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime LastUpDateTime { get; set; }

    }
}
