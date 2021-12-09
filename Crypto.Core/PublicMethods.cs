namespace Crypto.Core;

public class PublicMethods
{
    // Returns all instruments with specifications
    public string GetInstruments()
    {
        var endpoint = "/api/v3/instruments";
        return Utilities.MakeRequest("GET", endpoint);
    }


    // Returns market data for all instruments
    public string GetTickers()
    {
        var endpoint = "/api/v3/tickers";
        return Utilities.MakeRequest("GET", endpoint);
    }

    // Returns the entire order book for a futures
    public string GetOrderBook(string symbol)
    {
        var endpoint = "/api/v3/orderbook";
        var postUrl = "symbol=" + symbol;
        return Utilities.MakeRequest("GET", endpoint, postUrl);
    }

    // Returns historical data for futures and indices
    public string GetHistory(string symbol, DateTime lastTime)
    {
        var endpoint = "/api/v3/history";
        var postUrl = "symbol=" + symbol + "&lastTime=" + lastTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        return Utilities.MakeRequest("GET", endpoint, postUrl);
    }

    // Returns historical data for futures and indices
    public string GetHistory(string symbol)
    {
        var endpoint = "/api/v3/history";
        var postUrl = "symbol=" + symbol;
        return Utilities.MakeRequest("GET", endpoint, postUrl);
    }
}
