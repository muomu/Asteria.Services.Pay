using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Asteria.Services.Pay.H5Payment;

namespace Asteria.Services.Pay.Alipay
{
    class AlipayH5PaymentProvider : IH5PaymentProvider
    {
        public AlipayH5PaymentProvider(DefaultAopClient client)
        {
            Client = client;
        }

        public string Name { get; } = "ali";

        DefaultAopClient Client { get; }

        public Task<string> PayAsync(H5Trade trade, CancellationToken cancellationToken = default)
        {
            var request = new AlipayTradeWapPayRequest();
            var model = new AlipayTradeWapPayModel()
            {
                OutTradeNo = trade.TradeID,
                Subject = trade.Title,
                Body = trade.Description,
                TotalAmount = trade.Amount.ToString("0.00"),
            };

            request.SetBizModel(model);
            request.SetReturnUrl(trade.ReturnUrl);

            var body = Task.Run(() =>
            {
                var response = Client.pageExecute(request);
                return response.Body;
            }, cancellationToken);


            return body;
        }
    }
}
