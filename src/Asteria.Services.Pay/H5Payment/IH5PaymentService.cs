namespace Asteria.Services.Pay.H5Payment
{
    /// <summary>
    /// H5支付服务
    /// </summary>
    public interface IH5PaymentService
    {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="trade"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task PayAsync(H5Trade trade, CancellationToken cancellationToken = default);


    }
}
