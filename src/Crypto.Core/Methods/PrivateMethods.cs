using System.Net;

namespace Crypto.Core.Methods;

public class PrivateMethods
{
  private Utilities utilities;

  public PrivateMethods(string apiPath, string apiPublicKey, string apiPrivateKey, bool checkCertificate)
  {
    // TLS 1.2+ Supported 
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

    utilities = new Utilities(apiPath, apiPublicKey, apiPrivateKey, checkCertificate);
  }

  public string GetAccounts()
  {
    var endpoint = "/api/v3/accounts";
    return utilities.MakeRequest("GET", endpoint);
  }

  public string SendOrder(string orderType, string symbol, string side, decimal size, decimal limitPrice, decimal stopPrice = 0M)
  {
    var endpoint = "/api/v3/sendorder";
    string postBody;
    if (orderType.Equals("lmt"))
    {
      postBody = string.Format("orderType=lmt&symbol={0}&side={1}&size={2}&limitPrice={3}", symbol, side, size, limitPrice);
    }
    else if (orderType.Equals("stp"))
    {
      postBody = string.Format("orderType=stp&symbol={0}&side={1}&size={2}&limitPrice={3}&stopPrice={4}", symbol, side, size, limitPrice, stopPrice);
    }
    else
    {
      postBody = string.Empty;
    }

    return utilities.MakeRequest("POST", endpoint, string.Empty, postBody);
  }

  public string EditOrder(Dictionary<string, string> parameters)
  {
    var endpoint = "/api/v3/editorder";
    string postBody = string.Join("&", parameters.Select(kv => kv.Key + "=" + kv.Value).ToArray());
    return utilities.MakeRequest("POST", endpoint, string.Empty, postBody);
  }

  public string CancelOrder(string orderId)
  {
    var endpoint = "/api/v3/cancelorder";
    var postBody = "order_id=" + orderId;
    return utilities.MakeRequest("POST", endpoint, string.Empty, postBody);
  }

  public string CancelAllOrders()
  {
    var endpoint = "/api/v3/cancelallorders";
    return utilities.MakeRequest("POST", endpoint);
  }

  public string CancelAllOrdersAfter(int timeoutInSec)
  {
    var endpoint = "/api/v3/cancelallordersafter";
    var postUrl = "timeout=" + timeoutInSec;
    return utilities.MakeRequest("POST", endpoint, postUrl);
  }

  public string SendBatchOrder(string jsonElement)
  {
    var endpoint = "/api/v3/batchorder";
    var postBody = "json=" + jsonElement;
    return utilities.MakeRequest("POST", endpoint, string.Empty, postBody);
  }

  public string GetOpenOrders()
  {
    var endpoint = "/api/v3/openorders";
    return utilities.MakeRequest("GET", endpoint);
  }

  public string GetFills(DateTime lastFillTime)
  {
    var endpoint = "/api/v3/fills";
    var postUrl = "lastFillTime=" + lastFillTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
    return utilities.MakeRequest("GET", endpoint, postUrl);
  }

  public string GetFills()
  {
    var endpoint = "/api/v3/fills";
    return utilities.MakeRequest("GET", endpoint);
  }

  public string GetOpenPositions()
  {
    var endpoint = "/api/v3/openpositions";
    return utilities.MakeRequest("GET", endpoint);
  }

  public string GetRecentOrders(string? symbol = null)
  {
    var endpoint = "/api/v3/recentorders";
    var postUrl = symbol != null ? "symbol=" + symbol : "";
    return utilities.MakeRequest("GET", endpoint, postUrl);
  }

  public string GetNotifications()
  {
    var endpoint = "/api/v3/notifications";
    return utilities.MakeRequest("GET", endpoint);
  }

  public string GetTransfers(DateTime lastTransferTime)
  {
    var endpoint = "/api/v3/transfers";
    var postUrl = "lastTransferTime=" + lastTransferTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
    return utilities.MakeRequest("GET", endpoint, postUrl);
  }

  public string GetTransfers()
  {
    var endpoint = "/api/v3/transfers";
    return utilities.MakeRequest("GET", endpoint);
  }
}
