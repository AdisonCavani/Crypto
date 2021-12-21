using System.Text.Json.Serialization;

namespace Crypto.Core.ApiResult.Public;

public class ServerTime
{
    [JsonPropertyName("error")]
    public string[]? Error { get; set; }

    [JsonPropertyName("result")]
    public ResultObject? Result { get; set; }

    public partial class ResultObject
    {
        [JsonPropertyName("unixtime")]
        public int? UnixTime { get; set; }

        [JsonPropertyName("rfc1123")]
        public string? Rfc1123 { get; set; }
    }
}