namespace Asteria.Services.Pay
{
    /// <summary>
    /// 表示支付供应商
    /// </summary>
    public interface IPaymentProvider
    {
        /// <summary>
        /// 获取该支付供应商的名称
        /// </summary>
        string Name { get; }
    }
}
