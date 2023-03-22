using Asteria.Services.Pay;
using Asteria.Services.Pay.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPaymentServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IPayCallbackHandler, PayCallbackHandler>();
            return services;
        }

    }
}
