using Crypto.Core.ApiResult.Public;
using Crypto.Core.Settings;
using System.Text.Json;

namespace Crypto.Core.Methods;

public class PublicMethods
{
    private Utilities utilities;
    public PublicMethods()
    {
        utilities = new Utilities();
    }
    public ServerTime? GetServerTime()
    {
        var endpoint = PublicEndpoints.ServerTime;
        var result = utilities.MakeRequest("GET", endpoint);

        return JsonSerializer.Deserialize<ServerTime>(result);
    }


    // public SystemStatus? GetSystemStatus()
    // {
    //     var endpoint = PublicEndpoints.SystemStatus;
    //     string result = utilities.MakeRequest("GET", endpoint);

    //     return JsonSerializer.Deserialize<SystemStatus>(result);
    // }

    // public Assets? GetAssetInfo(List<string>? asset = default)
    // {
    //     var endpoint = PublicEndpoints.AssetInfo;
    //     if (asset is not null)
    //     {
    //         var postUrl = "asset=" + string.Join(',', asset);
    //         var result = utilities.MakeRequest("GET", endpoint, postUrl);
    //         return JsonSerializer.Deserialize<Assets>(result);
    //     }
    //     else
    //     {
    //         var result = utilities.MakeRequest("GET", endpoint);
    //         return JsonSerializer.Deserialize<Assets>(result);
    //     }
    // }


    // public AssetPairs? GetAssetPairs(List<string>? pair = default)
    // {
    //     var endpoint = PublicEndpoints.AssetPairs;

    //     if (pair is not null)
    //     {
    //         var postUrl = "pair=" + string.Join(',', pair);
    //         var result = utilities.MakeRequest("GET", endpoint, postUrl);
    //         return JsonSerializer.Deserialize<AssetPairs>(result);
    //     }
    //     else
    //     {
    //         var result = utilities.MakeRequest("GET", endpoint);
    //         return JsonSerializer.Deserialize<AssetPairs>(result);
    //     }
    // }

    // public string GetTicker()
    // {
    //     var endpoint = PublicEndpoints.Ticker;
    //     return utilities.MakeRequest("GET", endpoint);
    // }

    // public string GetOHLC()
    // {
    //     var endpoint = PublicEndpoints.OHLC;
    //     return utilities.MakeRequest("GET", endpoint);
    // }

    // public string GetDepth()
    // {
    //     var endpoint = PublicEndpoints.Depth;
    //     return utilities.MakeRequest("GET", endpoint);
    // }

    // public string GetTrades()
    // {
    //     var endpoint = PublicEndpoints.Trades;
    //     return utilities.MakeRequest("GET", endpoint);
    // }

    // public string GetSpread()
    // {
    //     var endpoint = PublicEndpoints.Spread;
    //     return utilities.MakeRequest("GET", endpoint);
    // }
}

public class NewPublicMethods
{
    public static async Task<ServerTime> GetServerTime()
    {
        var endpoint = PublicEndpoints.ServerTime;
        var url = ApiSettings.ApiPath + endpoint;

        using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<ServerTime>();
            else
                throw new Exception(response.ReasonPhrase);
        }
    }
}
