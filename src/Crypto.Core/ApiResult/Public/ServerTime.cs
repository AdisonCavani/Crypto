using System.Text.Json.Serialization;

namespace Crypto.Core.ApiResult.Public;

public class ServerTime
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
    [JsonPropertyName("unixtime")]
    public int? unixtime { get; set; }

    [JsonPropertyName("rfc1123")]
    public string? rfc1123 { get; set; }
  }
}