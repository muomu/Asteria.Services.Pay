namespace Asteria.Services.Pay.H5Payment
{

    /// <summary>
    /// H5支付提供者
    /// </summary>
    public interface IH5PaymentProvider : IPaymentProvider
    {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="trade"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> PayAsync(H5Trade trade, CancellationToken cancellationToken = default);

    }
}
