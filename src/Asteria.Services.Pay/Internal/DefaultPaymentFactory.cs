using Microsoft.Extensions.DependencyInjection;

namespace Asteria.Services.Pay
{
    class DefaultPaymentFactory : IPaymentProviderFactory
    {
        public DefaultPaymentFactory(IServiceProvider serviceProvider)
        {
            Providers = serviceProvider.GetServices<IPaymentProvider>();
        }

        IEnumerable<IPaymentProvider> Providers { get; }

        public T Create<T>(string channel) where T : IPaymentProvider
        {
            if (Providers.FirstOrDefault(e => e.Name.Equals(channel, StringComparison.OrdinalIgnoreCase)) is not IPaymentProvider provider)
            {
                throw new NotSupportedException($"不支持的支付渠道 '{channel}'");
            }

            return (T)provider;

        }
    }
}
