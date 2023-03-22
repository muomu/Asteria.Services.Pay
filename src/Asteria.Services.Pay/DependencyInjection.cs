using Asteria.Services.Pay;
using Asteria.Services.Pay.H5Payment;
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
        /// <returns></returns>
        public static IServiceCollection AddPaymentDomainServices(this IServiceCollection services)
        {
            services.TryAddSingleton<IPaymentProviderFactory, DefaultPaymentFactory>();
            services.TryAddSingleton<IH5PaymentService, DefaultH5PaymentService>();
            return services;
        }

        /// <summary>
        /// 添加支付供应商
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPayProvider<T>(this IServiceCollection services) where T : IPaymentProvider
        {
            if (!services.Where(e => e.ServiceType == typeof(IPaymentProvider)).Any(e => e.ImplementationType == typeof(T)))
            {
                services.Add(new ServiceDescriptor(typeof(IPaymentProvider), typeof(T), ServiceLifetime.Singleton));
            }
            return services;
        }
    }
}
