using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Asteria.Services.Pay.Alipay.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("alipay/v1/notify")]
    [ApiController]
    public class AlipayController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="alipayTradeService"></param>
        /// <param name="payCallbackHandler"></param>
        public AlipayController(ILogger<AlipayController> logger, IAlipayTradeService alipayTradeService, IPayCallbackHandler payCallbackHandler)
        {
            Logger = logger;
            AlipayTradeService = alipayTradeService;
            PayCallbackHandler = payCallbackHandler;
        }

        ILogger<AlipayController> Logger { get; }

        IAlipayTradeService AlipayTradeService { get; }
        IPayCallbackHandler PayCallbackHandler { get; }


        /// <summary>
        /// 创建交易订单
        /// </summary>
        /// <param name="trade_no"></param>
        /// <param name="out_trade_no"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTradeAsync([FromForm] string trade_no, [FromForm] string out_trade_no, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(trade_no))
            {
                throw new ArgumentException($"“{nameof(trade_no)}”不能为 null 或空。", nameof(trade_no));
            }

            if (string.IsNullOrEmpty(out_trade_no))
            {
                throw new ArgumentException($"“{nameof(out_trade_no)}”不能为 null 或空。", nameof(out_trade_no));
            }

            Logger.LogInformation("支付通知：\n - TradeNo: {trade_no} \n - OutTradeNo: {out_trade_no} \n", trade_no, out_trade_no);

            if (await AlipayTradeService.QueryTradeAsync(out_trade_no, cancellationToken) is not TradeVoucher tradeVoucher)
            {
                return BadRequest("未查询到订单");
            }

            if (!await PayCallbackHandler.HandleAsync(tradeVoucher, cancellationToken))
            {
                return BadRequest("订单异常");
            }

            return Ok();

        }
    }
}
