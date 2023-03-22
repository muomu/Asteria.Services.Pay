using Aop.Api;
using Asteria.Services.Pay.Alipay;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddAlipayService(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection("Payment:Alipay").Get<AlipayOption>() ?? throw new InvalidOperationException("未提供Alipay支付参数");
            services.TryAddSingleton(sp =>
            {
                DefaultAopClient aopClient = new(config.Endpoint, config.AppId, config.PrivateKey, config.Format, config.Version, config.SignType, config.PublicKey, config.Charset, false);
                aopClient.SetTimeout(config.TimeoutMillisec);
                aopClient.notify_url = config.NotifyUrl;
                return aopClient;
            });

            services.TryAddSingleton<IAlipayTradeService, AlipayTradeService>();
            services.AddPayProvider<AlipayH5PaymentProvider>();

            return services;
        }
    }
}
