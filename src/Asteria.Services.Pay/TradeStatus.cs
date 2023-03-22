namespace Asteria.Services.Pay
{
    /// <summary>
    /// 提供交易状态标识
    /// </summary>
    public static class TradeStatus
    {
        /// <summary>
        /// 标识交易已经完成
        /// </summary>
        public const string Complated = "Complated";
        /// <summary>
        /// 标识交易订单已经打开，尚未付款
        /// </summary>
        public const string Opened = "Opened";

        /// <summary>
        /// 标识交易失败
        /// </summary>
        public const string Faild = "Faild";
    }
}
