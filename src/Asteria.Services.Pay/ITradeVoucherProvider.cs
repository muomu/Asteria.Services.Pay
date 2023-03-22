namespace Asteria.Services.Pay
{
    /// <summary>
    /// 提供交易凭证
    /// </summary>
    public interface ITradeVoucherProvider
    {
        /// <summary>
        /// 获取指定的交易凭证信息
        /// </summary>
        /// <param name="tradeId">将要检索的交易订单唯一标识</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TradeVoucher?> GetTradeAsync(string tradeId, CancellationToken cancellationToken = default);
    }
}
