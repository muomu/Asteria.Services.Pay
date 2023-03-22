namespace Asteria.Services.Pay
{
    /// <summary>
    /// 提供支付回调处理
    /// </summary>
    public interface IPayCallbackHandler
    {
        /// <summary>
        /// 处理支付回调
        /// </summary>
        /// <param name="tradeVoucher"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> HandleAsync(TradeVoucher tradeVoucher, CancellationToken cancellationToken = default);
    }
}
