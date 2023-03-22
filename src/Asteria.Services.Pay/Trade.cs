using System.ComponentModel.DataAnnotations;

namespace Asteria.Services.Pay
{

    public abstract class Trade
    {


        [Key]
        [MaxLength(128)]
        public string TradeID { get; init; } = null!;

        /// <summary>
        /// 支付渠道
        /// </summary>
        [MaxLength(16)]
        public string Channel { get; set; } = null!;

        [MaxLength(16)]
        public string Title { get; set; } = null!;

        [MaxLength(300)]
        public string Description { get; set; } = null!;

        public double Amount { get; set; }

        public DateTime CreationTime { get; set; }

        [MaxLength(16)]
        public string Status { get; set; } = null!;
    }
}
