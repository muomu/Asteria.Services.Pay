namespace Asteria.Services.Pay
{

    /// <summary>
    /// 支付供应商工厂
    /// </summary>
    public interface IPaymentProviderFactory
    {
        /// <summary>
        /// 创建支付服务
        /// </summary>
        /// <param name="channel">支付提供商</param>
        /// <returns></returns>
        T Create<T>(string channel) where T : IPaymentProvider;
    }

}
