using Crypto.Core.Methods;
using Microsoft.Extensions.Configuration;

namespace Crypto;

public class ApiTest
{
    static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
        .AddUserSecrets<ApiTest>()
        .Build();

        var pm = new PublicMethods(configuration["Api:Path"], Convert.ToBoolean(configuration["Api:CheckCertificate"]));
        var ppm = new PrivateMethods(configuration["Api:Path"], configuration["Api:PublicKey"], configuration["Api:PrivateKey"], Convert.ToBoolean(configuration["Api:CheckCertificate"]));

        /*---------------------------------------------------------*/
        /*                      Server time                        */
        /*---------------------------------------------------------*/
        Console.WriteLine("Server time:");
        var serverTime = pm.GetServerTime();
        Console.WriteLine(serverTime?.Result?.Rfc1123);
        Console.WriteLine(serverTime?.Result?.UnixTime);

        if (serverTime?.Error?.Length > 0)
        {
            Console.WriteLine("Errors:");
            foreach (var item in serverTime.Error)
                Console.WriteLine(item);
        }
        Console.WriteLine();

        /*---------------------------------------------------------*/
        /*                     System status                       */
        /*---------------------------------------------------------*/
        Console.WriteLine("System status:");
        var systemStatus = pm.GetSystemStatus();
        Console.WriteLine(pm.GetSystemStatus()?.Result?.Status);
        Console.WriteLine(pm.GetSystemStatus()?.Result?.Timestamp);

        if (systemStatus?.Error?.Length > 0)
        {
            Console.WriteLine("Errors:");
            foreach (var item in systemStatus.Error)
                Console.WriteLine(item);
        }
        Console.WriteLine();

        /*---------------------------------------------------------*/
        /*                       Asset info                        */
        /*---------------------------------------------------------*/
        Console.WriteLine("Asset info:");
        var assetInfoList = new List<string>();
        assetInfoList.Add("XBT");
        assetInfoList.Add("ETH");
        var assetInfo = pm.GetAssetInfo(assetInfoList);

        if (assetInfo?.Result is not null)
            foreach (var item in assetInfo.Result)
                Console.WriteLine(item.Value.DisplayDecimals);

        if (assetInfo?.Error?.Length > 0)
        {
            Console.WriteLine("Errors:");
            foreach (var item in assetInfo.Error)
                Console.WriteLine(item);
        }
        Console.WriteLine();

        /*---------------------------------------------------------*/
        /*                   Tradable asset info                   */
        /*---------------------------------------------------------*/
        Console.WriteLine("Tradable asset pairs:");
        var assetPairsList = new List<string>();
        assetPairsList.Add("XXBTZUSD");
        assetPairsList.Add("XETHXXBT");
        var assetPairs = pm.GetAssetPairs(assetPairsList);

        if (assetPairs?.Result is not null)
            foreach (var item in assetPairs.Result)
            {
                if (item.Value.Fees is not null)
                {
                    foreach (var fees in item.Value.Fees)
                    {
                        foreach (var fee in fees)
                        {
                            Console.Write(" | " + fee);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }


        if (assetPairs?.Error?.Length > 0)
        {
            Console.WriteLine("Errors:");
            foreach (var item in assetPairs.Error)
                Console.WriteLine(item);
        }
        Console.WriteLine();
    }
}
