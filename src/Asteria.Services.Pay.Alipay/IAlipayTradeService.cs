using System.ComponentModel.DataAnnotations;

namespace Asteria.Services.Pay.Alipay
{
    /// <summary>
    /// Alipay支付服务
    /// </summary>
    public interface IAlipayTradeService
    {
        /// <summary>
        /// 交易查询
        /// </summary>
        /// <param name="tradeId">支付宝交易号</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TradeVoucher?> QueryTradeAsync([MaxLength(64)]string tradeId, CancellationToken cancellationToken = default);
    }
}
