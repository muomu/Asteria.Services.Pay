using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asteria.Services.Pay
{
    /// <summary>
    /// 交易凭证
    /// </summary>
    public class TradeVoucher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        protected int ID { get; init; }

        /// <summary>
        /// 交易id
        /// </summary>
        public string TransactionId { get; set; } = null!;

        /// <summary>
        /// 买家标识
        /// </summary>
        public string Buyer { get; set; } = null!;

        /// <summary>
        /// 订单号
        /// </summary>
        public string TradeId { get; set; } = null!;

        /// <summary>
        /// 付款金额 (分)
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime PaidTime { get; set; }
    }
}
