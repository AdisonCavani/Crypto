namespace Crypto.Core;

public class PublicMethods
{
  private Utilities utilities;
  public PublicMethods(string apiPath, bool checkCertificate)
  {
    utilities = new Utilities(apiPath, checkCertificate);
  }
  public string GetServerTime()
  {
    var endpoint = PublicEndpoints.ServerTime;
    return utilities.MakeRequest("GET", endpoint);
  }


  public string GetSystemStatus()
  {
    var endpoint = PublicEndpoints.SystemStatus;
    return utilities.MakeRequest("GET", endpoint);
  }

  public string GetAssetInfo(string symbol)
  {
    var endpoint = PublicEndpoints.AssetInfo;
    return utilities.MakeRequest("GET", endpoint);
  }


  public string GetAssetPairs()
  {
    var endpoint = PublicEndpoints.AssetPairs;
    return utilities.MakeRequest("GET", endpoint);
  }

  public string GetTicker()
  {
    var endpoint = PublicEndpoints.Ticker;
    return utilities.MakeRequest("GET", endpoint);
  }

  public string GetOHLC()
  {
    var endpoint = PublicEndpoints.OHLC;
    return utilities.MakeRequest("GET", endpoint);
  }

  public string GetDepth()
  {
    var endpoint = PublicEndpoints.Depth;
    return utilities.MakeRequest("GET", endpoint);
  }

  public string GetTrades()
  {
    var endpoint = PublicEndpoints.Trades;
    return utilities.MakeRequest("GET", endpoint);
  }

  public string GetSpread()
  {
    var endpoint = PublicEndpoints.Spread;
    return utilities.MakeRequest("GET", endpoint);
  }
}
