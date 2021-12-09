namespace Crypto.Core;

public class PrivateMethods
{
    // Returns key account information
    public string GetAccounts()
    {
        var endpoint = "/api/v3/accounts";
        return Utilities.MakeRequest("GET", endpoint);
    }

    // Places an order
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

        return Utilities.MakeRequest("POST", endpoint, string.Empty, postBody);
    }

    // Edits an order
    public string EditOrder(Dictionary<string, string> parameters)
    {
        var endpoint = "/api/v3/editorder";
        string postBody = string.Join("&", parameters.Select(kv => kv.Key + "=" + kv.Value).ToArray());
        return Utilities.MakeRequest("POST", endpoint, string.Empty, postBody);
    }

    // Cancels an order
    public string CancelOrder(string orderId)
    {
        var endpoint = "/api/v3/cancelorder";
        var postBody = "order_id=" + orderId;
        return Utilities.MakeRequest("POST", endpoint, string.Empty, postBody);
    }

    // Cancels all orders
    public string CancelAllOrders()
    {
        var endpoint = "/api/v3/cancelallorders";
        return Utilities.MakeRequest("POST", endpoint);
    }

    // Dead Man Switch. Cancels all orders after X
    public string CancelAllOrdersAfter(int timeoutInSec)
    {
        var endpoint = "/api/v3/cancelallordersafter";
        var postUrl = "timeout=" + timeoutInSec;
        return Utilities.MakeRequest("POST", endpoint, postUrl);
    }

    // Places or cancels orders in batch
    public string SendBatchOrder(string jsonElement)
    {
        var endpoint = "/api/v3/batchorder";
        var postBody = "json=" + jsonElement;
        return Utilities.MakeRequest("POST", endpoint, string.Empty, postBody);
    }

    // Returns all open orders
    public string GetOpenOrders()
    {
        var endpoint = "/api/v3/openorders";
        return Utilities.MakeRequest("GET", endpoint);
    }

    // Returns filled orders
    public string GetFills(DateTime lastFillTime)
    {
        var endpoint = "/api/v3/fills";
        var postUrl = "lastFillTime=" + lastFillTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        return Utilities.MakeRequest("GET", endpoint, postUrl);
    }

    // Returns filled orders
    public string GetFills()
    {
        var endpoint = "/api/v3/fills";
        return Utilities.MakeRequest("GET", endpoint);
    }

    // Returns all open positions
    public string GetOpenPositions()
    {
        var endpoint = "/api/v3/openpositions";
        return Utilities.MakeRequest("GET", endpoint);
    }

    // Returns recent orders
    public string GetRecentOrders(string? symbol = null)
    {
        var endpoint = "/api/v3/recentorders";
        var postUrl = symbol != null ? "symbol=" + symbol : "";
        return Utilities.MakeRequest("GET", endpoint, postUrl);
    }

    // Returns the platform noticiations
    public string GetNotifications()
    {
        var endpoint = "/api/v3/notifications";
        return Utilities.MakeRequest("GET", endpoint);
    }

    // Returns xbt transfers
    public string GetTransfers(DateTime lastTransferTime)
    {
        var endpoint = "/api/v3/transfers";
        var postUrl = "lastTransferTime=" + lastTransferTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        return Utilities.MakeRequest("GET", endpoint, postUrl);
    }

    // Returns xbt transfers
    public string GetTransfers()
    {
        var endpoint = "/api/v3/transfers";
        return Utilities.MakeRequest("GET", endpoint);
    }
}
