using System.Text.Json.Serialization;

namespace Crypto.Core.ApiResult.Public;

public class SystemStatus
{
  [JsonPropertyName("error")]
  public List<Error>? error { get; set; }

  [JsonPropertyName("result")]
  public Result? result { get; set; }

  public partial class Error
  {

  }

  public partial class Result
  {
    [JsonPropertyName("status")]
    public string? status { get; set; }

    [JsonPropertyName("timestamp")]
    public string? timestamp { get; set; }
  }
}