namespace Asteria.Services.Pay.H5Payment
{
    /// <summary>
    /// 表示H5支付订单
    /// </summary>
    public class H5Trade : Trade
    {
        /// <summary>
        /// 获取支付回调Url
        /// </summary>
        public string ReturnUrl { get; init; } = null!;

        /// <summary>
        /// 获取关闭支付Url
        /// </summary>
        public string QuitUrl { get; init; } = null!;

        /// <summary>
        /// 获取支付回调Url
        /// </summary>
        public string CallbackUrl { get; init; } = null!;

        /// <summary>
        /// 获取HtmlText
        /// </summary>
        public string HtmlText { get; set; } = null!;
    }
}
