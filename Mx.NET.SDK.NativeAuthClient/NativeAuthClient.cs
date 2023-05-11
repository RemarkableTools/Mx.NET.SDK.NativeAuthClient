using Mx.NET.SDK.NativeAuthClient.Data;
using Mx.NET.SDK.NativeAuthClient.Entities;
using Newtonsoft.Json;
using System.Text;

namespace Mx.NET.SDK.NativeAuthClient
{
    public class NativeAuthClient
    {
        private readonly NativeAuthClientConfig _config;
        public NativeAuthClient(NativeAuthClientConfig config)
        {
            _config = config;
        }

        public async Task<string> GenerateToken()
        {
            var origin = EncodeValue(_config.Origin);

            var block = await GetCurrentBlock();

            var extraInfo = new ExtraInfo(block.Timestamp);
            var extra = EncodeValue(JsonConvert.SerializeObject(extraInfo));

            return $"{origin}.{block.Hash}.{_config.ExpirySeconds}.{extra}";
        }

        private async Task<Block> GetCurrentBlock()
        {
            var url = $"{_config.ApiUrl}/blocks?size=1&fields=hash,timestamp";
            if (_config.BlockHashShard != null)
                url += $"&shard={_config.BlockHashShard}";
            var response = await new HttpClient().GetAsync(url);
            var blocks = JsonConvert.DeserializeObject<Block[]>(await response.Content.ReadAsStringAsync());
            if (!response.IsSuccessStatusCode || blocks is null)
                throw new Exception("Could not get the Block from API");

            return blocks[0];
        }

        private static string EncodeValue(string value)
            => Escape(Convert.ToBase64String(Encoding.UTF8.GetBytes(value)));

        private static string Escape(string value)
            => value.Replace('+', '-').Replace('/', '_').Replace("=", "");
    }
}