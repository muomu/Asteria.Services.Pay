using Asteria.Services.Pay.H5Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Asteria.Services.Pay.EntityFrameworkCore
{
    class PayCallbackHandler : IPayCallbackHandler
    {
        public PayCallbackHandler(MainDbContext dB, ILogger<PayCallbackHandler> logger, IHttpClientFactory httpClientFactory)
        {
            DB = dB;
            Logger = logger;
            HttpClientFactory = httpClientFactory;
        }

        MainDbContext DB { get; }
        ILogger<PayCallbackHandler> Logger { get; }
        IHttpClientFactory HttpClientFactory { get; }

        public async Task<bool> HandleAsync(TradeVoucher tradeVoucher, CancellationToken cancellationToken = default)
        {
            if (await DB.H5Trades.FirstOrDefaultAsync(e => e.TradeID == tradeVoucher.TradeId, cancellationToken) is not H5Trade trade)
            {
                return false;
            }

            if (trade.Status == TradeStatus.Complated)
            {
                Logger.LogWarning($"订单 '{trade.TradeID}' 已完成，跳过处理.");
                return true;
            }


            if (trade.Amount != tradeVoucher.Amount)
            {
                Logger.LogError($"订单 '{trade.TradeID}' 的金额 '{trade.Amount}' 与支付方的 '{tradeVoucher.Amount}' 不一致");

                trade.Status = TradeStatus.Faild;
                await DB.SaveChangesAsync(cancellationToken);

                return false;
            }

            HttpResponseMessage response;

            using (var client = HttpClientFactory.CreateClient())
            {
                response = await client.GetAsync($"{trade.CallbackUrl}?tradeId={trade.TradeID}&amount={trade.Amount}", cancellationToken);
            }

            if (!response.IsSuccessStatusCode)
            {
                trade.Status = TradeStatus.Faild;
                await DB.SaveChangesAsync(cancellationToken);

                return false;
            }
            else
            {
                trade.Status = TradeStatus.Complated;
                await DB.SaveChangesAsync(cancellationToken);

                return true;
            }
        }

    }
}
