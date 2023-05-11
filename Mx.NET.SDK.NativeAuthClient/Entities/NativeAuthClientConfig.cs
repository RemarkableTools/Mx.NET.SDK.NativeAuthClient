namespace Mx.NET.SDK.NativeAuthClient.Entities
{
    public class NativeAuthClientConfig
    {
        public string Origin { get; set; } = "";
        public string ApiUrl { get; set; } = "https://api.multiversx.com";
        public int ExpirySeconds { get; set; } = 60 * 60 * 24;
        public int? BlockHashShard { get; set; }
    }
}
