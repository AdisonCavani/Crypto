using Crypto.Core;

namespace com.cryptofacilities.REST.v3.Examples;

class APITester
{
    private static readonly string apiPath = "https://api.kraken.com/0/public";
    private static readonly string apiPublicKey = "";
    private static readonly string apiPrivateKey = "";

    private static readonly bool checkCertificate = true;

    static void Main()
    {
        CfApiMethods methods;
        string result, symbol;


        /*---------------------------Public Endpoints-----------------------------------------------*/

        methods = new CfApiMethods(apiPath, checkCertificate);

        // Get instruments
        result = methods.GetInstruments();
        Console.WriteLine("getInstruments:\n" + result);


        /*----------------------------Private Endpoints----------------------------------------------*/
        methods = new CfApiMethods(apiPath, apiPublicKey, apiPrivateKey, checkCertificate);

        // Get accounts
        result = methods.GetAccounts();
        Console.WriteLine("getAccounts:\n" + result);

        // Get open orders
        result = methods.GetOpenOrders();
        Console.WriteLine("getOpenOrders:\n" + result);

        // Get fills
        var lastFillTime = new DateTime(2016, 2, 1);
        result = methods.GetFills(lastFillTime);
        Console.WriteLine("getFills:\n" + result);

        // Get open positions
        result = methods.GetOpenPositions();
        Console.WriteLine("getOpenPositions:\n" + result);

        // Get recent orders
        //symbol = "USD";
        //result = methods.GetRecentOrders(symbol);
        //Console.WriteLine("getRecentOrders:\n" + result);

        // Get notificaitons
        result = methods.GetNotifications();
        Console.WriteLine("getNotifications:\n" + result);

        // Get xbt transfers
        result = methods.GetTransfers();
        Console.WriteLine("getTransfers:\n" + result);

        Console.ReadKey();
    }
}