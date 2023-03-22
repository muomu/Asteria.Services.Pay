namespace Asteria.Services.Pay.Alipay
{
    /// <summary>
    /// 提供Alipay配置所需的所有信息
    /// </summary>
    public class AlipayOption
    {
        /// <summary>
        /// 获取或设置支付Endpoint
        /// </summary>
        public string Endpoint { get; set; } = null!;

        /// <summary>
        /// 获取或设置支付AppId
        /// </summary>
        public string AppId { get; set; } = null!;

        /// <summary>
        /// 获取或设置支付私钥
        /// </summary>
        public string PrivateKey { get; set; } = null!;

        /// <summary>
        /// 获取或设置支付公钥
        /// </summary>
        public string PublicKey { get; set; } = null!;

        /// <summary>
        /// 获取或设置通知Url
        /// </summary>
        public string NotifyUrl { get; set; } = null!;

        /// <summary>
        /// 获取或设置请求超时时间（毫秒）
        /// </summary>
        public int TimeoutMillisec { get; set; } = 3000;

        /// <summary>
        /// 获取或设置传输格式
        /// </summary>
        public string Format { get; set; } = "json";

        /// <summary>
        /// 获取或设置客户端版本
        /// </summary>
        public string Version { get; set; } = "1.0";

        /// <summary>
        /// 获取或设置加密类型
        /// </summary>
        public string SignType { get; set; } = "RSA2";

        /// <summary>
        /// 获取或设置传输字符格式
        /// </summary>
        public string Charset { get; set; } = "utf-8";
    }
}
