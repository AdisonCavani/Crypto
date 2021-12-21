using System.Text.Json.Serialization;

namespace Crypto.Core.ApiResult.Public;

public class Assets
{
    [JsonPropertyName("error")]
    public string[]? Error { get; set; }

    [JsonPropertyName("result")]
    public Dictionary<string, AssetInfo>? Result { get; set; }

    public partial class AssetInfo
    {
        [JsonPropertyName("aclass")]
        public string? AssetClass { get; set; }

        [JsonPropertyName("altname")]
        public string? AltName { get; set; }

        [JsonPropertyName("decimals")]
        public int? Decimals { get; set; }

        [JsonPropertyName("display_decimals")]
        public int? DisplayDecimals { get; set; }
    }
}