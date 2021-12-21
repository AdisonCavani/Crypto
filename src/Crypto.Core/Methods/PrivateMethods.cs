using System.Net;
using Crypto.Core.Methods.HttpRequest;

namespace Crypto.Core.Methods;

public class PrivateMethods
{
    private Utilities utilities;

    public PrivateMethods(string apiPublicKey, string apiPrivateKey)
    {
        // TLS 1.3+ Supported 
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;

        utilities = new Utilities(apiPublicKey, apiPrivateKey);
    }

    public string GetAccountBalance()
    {
        var endpoint = PrivateEndpoints.Balance;

        var result = utilities.MakeRequest(HttpRequestMethods.POST, endpoint, string.Empty, "");

        return result;
    }
}
