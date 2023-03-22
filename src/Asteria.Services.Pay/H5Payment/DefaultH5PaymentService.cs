namespace Asteria.Services.Pay.H5Payment
{
    class DefaultH5PaymentService : IH5PaymentService
    {
        private readonly IPaymentProviderFactory _paymentProviderFactory;

        public DefaultH5PaymentService(IPaymentProviderFactory paymentFactory)
        {
            _paymentProviderFactory = paymentFactory;
        }


        public async Task PayAsync(H5Trade trade, CancellationToken cancellationToken = default)
        {
            var provider = _paymentProviderFactory.Create<IH5PaymentProvider>(trade.Channel);

            var html = await provider.PayAsync(trade, cancellationToken);

            trade.HtmlText = html;
            trade.Status = TradeStatus.Opened;
        }
    }
}
