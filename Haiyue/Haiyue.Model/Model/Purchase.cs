using Haiyue.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Haiyue.Model.Model
{
    public class Purchase:BaseModel
    {
        /// <summary>
        /// 游戏外键ID
        /// </summary>
        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }

        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// 服务器名称
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalNumber { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public double UnitPrice { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public double TotalPrice { get; set; }

        /// <summary>
        /// 币种外键ID
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// 币种外键
        /// </summary>
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }

        /// <summary>
        /// 实收
        /// </summary>
        public double RealIncome { get; set; }

        /// <summary>
        /// 实收RMB
        /// </summary>
        public double RealIncomeRMB { get; set; }

        /// <summary>
        /// 供应商联系方式
        /// </summary>
        public string SupplierPhone { get; set; }

        /// <summary>
        /// 支付账号
        /// </summary>
        public string PaymentAccount { get; set; }

        /// <summary>
        /// 付款状态
        /// </summary>
        public PaymentStatusType PaymentStatus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public int HandlerId { get; set; }

        [ForeignKey("HandlerId")]
        public User User { get; set; }
    }
}
