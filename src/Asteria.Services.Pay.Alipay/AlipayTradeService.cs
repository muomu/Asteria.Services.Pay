using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using Microsoft.Extensions.Logging;

namespace Asteria.Services.Pay.Alipay
{
    class AlipayTradeService : IAlipayTradeService
    {
        public AlipayTradeService(DefaultAopClient client, ILogger<IAlipayTradeService> logger)
        {
            Client = client;
            Logger = logger;
        }

        DefaultAopClient Client { get; }
        ILogger<IAlipayTradeService> Logger { get; }

        public async Task<TradeVoucher?> QueryTradeAsync(string tradeId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(tradeId)) throw new ArgumentException($"{nameof(tradeId)}不能为空或空白字符");
            if (tradeId.Length > 64) throw new ArgumentException($"{nameof(tradeId)}超过支持的最大长度");

            AlipayTradeQueryRequest request = new();

            AlipayTradeQueryModel model = new()
            {
                OutTradeNo = tradeId
            };

            request.SetBizModel(model);

            var result = await Task.Run(() =>
            {
                var response = Client.SdkExecute<AlipayTradeQueryResponse>(request);

                if (response.IsError)
                {
                    Logger.LogError("调用支付查询接口失败：{Msg}", response.Msg);
                    return null;
                }
                if (!double.TryParse(response.TotalAmount, out var amount))
                {
                    Logger.LogError("无效的金额{TotalAmount}", response.TotalAmount);
                    return null;
                }
                if (!DateTime.TryParse(response.SendPayDate, out var time))
                {
                    Logger.LogError("无效的时间{SendPayDate}", response.SendPayDate);
                    return null;
                }

                return new TradeVoucher
                {
                    TradeId = tradeId,
                    TransactionId = response.TradeNo,
                    Amount = (long)checked(amount * 100),
                    Buyer = response.BuyerUserId,
                    PaidTime = time
                };
            });

            return result;
        }
    }
}
