using System.Text.Json.Serialization;

namespace Crypto.Core.ApiResult.Public;

public class SystemStatus
{
    [JsonPropertyName("error")]
    public string[]? Error { get; set; }

    [JsonPropertyName("result")]
    public ResultObject? Result { get; set; }

    public partial class ResultObject
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("timestamp")]
        public string? Timestamp { get; set; }
    }
}