using Crypto.Core.Methods;

public class KrakenClient
{
    public PublicMethods Public { get; set; }
    public PrivateMethods Private { get; set; }

    public KrakenClient(string publicKey = "", string privateKey = "")
    {
        if (!string.IsNullOrWhiteSpace(publicKey) && !string.IsNullOrWhiteSpace(privateKey))
        {
            Public = new PublicMethods();
            Private = new PrivateMethods(publicKey, privateKey);
        }

        else
            Public = new PublicMethods();
    }
}