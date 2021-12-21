using System.Net.Http.Headers;

namespace Crypto.Core;

public static class ApiHelper
{
    public static HttpClient ApiClient { get; private set; }

    public static void InitializeClient()
    {
        ApiClient = new HttpClient();
        ApiClient.DefaultRequestHeaders.Accept.Clear();
        ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}
