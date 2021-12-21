using System.Text.Json.Serialization;

namespace Crypto.Core.ApiResult.Public;

public class AssetPairs
{
    [JsonPropertyName("error")]
    public string[]? Error { get; set; }

    [JsonPropertyName("result")]
    public Dictionary<string, AssetPair>? Result { get; set; }

    public partial class AssetPair
    {
        [JsonPropertyName("altname")]
        public string? AltName { get; set; }

        [JsonPropertyName("wsname")]
        public string? WebSocketName { get; set; }

        [JsonPropertyName("aclass_base")]
        public string? AssetClassBase { get; set; }

        [JsonPropertyName("base")]
        public string? Base { get; set; }

        [JsonPropertyName("aclass_quote")]
        public string? AssetClassQuote { get; set; }

        [JsonPropertyName("quote")]
        public string? Quote { get; set; }

        [JsonPropertyName("pair_decimals")]
        public int? PairDecimals { get; set; }

        [JsonPropertyName("lot_decimals")]
        public int? LotDecimals { get; set; }

        [JsonPropertyName("lot_multiplier")]
        public int? LotMultiplier { get; set; }

        [JsonPropertyName("leverage_buy")]
        public int[]? LeverageBuy { get; set; }

        [JsonPropertyName("leverage_sell")]
        public int[]? LeverageSell { get; set; }

        [JsonPropertyName("fees")]
        public double[][]? Fees { get; set; }

        [JsonPropertyName("fees_maker")]
        public double[][]? FeesMaker { get; set; }

        [JsonPropertyName("fee_volume_currency")]
        public string? FeeVolumeCurrency { get; set; }

        [JsonPropertyName("margin_call")]
        public int? MarginCall { get; set; }

        [JsonPropertyName("margin_stop")]
        public int? MarginStop { get; set; }

        [JsonPropertyName("ordermin")]
        public string? OrderMin { get; set; }
    }
}