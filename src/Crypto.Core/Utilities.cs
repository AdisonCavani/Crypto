using Crypto.Core.Settings;
using System.Collections.Specialized;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Crypto.Core;

public class Utilities
{
    private string apiPath => ApiSettings.ApiPath;
    private string? apiPublicKey { get; set; }
    private string? apiPrivateKey { get; set; }

    public Utilities()
    {

    }

    public Utilities(string apiPublicKey, string apiPrivateKey)
    {
        this.apiPublicKey = apiPublicKey;
        this.apiPrivateKey = apiPrivateKey;
    }

    /// <summary>
    /// Signs a message
    /// </summary>
    /// <param name="endpoint"></param>
    /// <param name="postData"></param>
    /// <param name="apiPrivateKey"></param>
    /// <returns></returns>
    public string SignMessage(string endpoint, string postData)
    {
        // Step 1: Concatenate postData + endpoint
        var message = postData + endpoint;

        // Step 2: Hash the result of step 1 with SHA256
        byte[]? hash;

        using (SHA256 hash256 = SHA256.Create())
        {
            hash = hash256.ComputeHash(Encoding.UTF8.GetBytes(message));
        }

        // Step 3: Base64 decode apiPrivateKey
        var secretDecoded = Convert.FromBase64String(apiPrivateKey);

        // Step 4: Use result of step 3 to hash the resultof step 2 with HMAC-SHA512
        var hmacsha512 = new HMACSHA512(secretDecoded);
        var hash2 = hmacsha512.ComputeHash(hash);

        // Step 5: Base64 encode the result of step 4 and return
        return Convert.ToBase64String(hash2);
    }

    /// <summary>
    /// Send a HTTP request
    /// </summary>
    /// <param name="requestMethod"></param>
    /// <param name="endpoint"></param>
    /// <param name="apiPath"></param>
    /// <param name="apiPublicKey"></param>
    /// <param name="apiPrivateKey"></param>
    /// <param name="checkCertificate"></param>
    /// <param name="postUrl"></param>
    /// <param name="postBody"></param>
    /// <returns></returns>
    public string MakeRequest(string requestMethod, string endpoint, string postUrl = "", string postBody = "")
    {
        using (var client = new WebClient())
        {
            var url = apiPath + endpoint + "?" + postUrl;

            // Create authentication headers
            if (apiPublicKey != null && apiPrivateKey != null)
            {
                var postData = postUrl + postBody;
                var signature = SignMessage(endpoint, postData);
                client.Headers.Add("APIKey", apiPublicKey);
                client.Headers.Add("Authent", signature);
            }

            if (requestMethod == "POST" && postBody.Length > 0)
            {
                NameValueCollection parameters = new();
                string[] bodyArray = postBody.Split('&');
                foreach (string pair in bodyArray)
                {
                    string[] splitPair = pair.Split('=');
                    parameters.Add(splitPair[0], splitPair[1]);
                }
                var response = client.UploadValues(url, "POST", parameters);
                return Encoding.UTF8.GetString(response);
            }
            else
            {
                return client.DownloadString(url);
            }
        }
    }

    public async Task<string> MakeGETRequest(string url)
    {
        using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsStringAsync().Result;
            else
                throw new Exception(response.ReasonPhrase);
        }
    }

    public async Task<string> MakePOSTRequest(string endpoint, string postUrl, string postBody)
    {
        using (var client = ApiHelper.ApiClient)
        {
            var url = apiPath + endpoint + "?" + postUrl;

            // Create authentication headers
            if (!string.IsNullOrWhiteSpace(apiPublicKey) && !string.IsNullOrWhiteSpace(apiPrivateKey))
            {
                var postData = postUrl + postBody;
                var signature = SignMessage(endpoint, postData);
                client.DefaultRequestHeaders.Add("APIKey", apiPublicKey);
                client.DefaultRequestHeaders.Add("Authent", signature);
            }

            NameValueCollection parameters = new NameValueCollection();

            string[] bodyArray = postBody.Split('&');
            foreach (string pair in bodyArray)
            {
                string[] splitPair = pair.Split('=');
                parameters.Add(splitPair[0], splitPair[1]);
            }

            StringContent content = new("");

            var response = await client.PostAsync(url, content);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
