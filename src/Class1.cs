using System.Net;

namespace Crypto.Core;

public class CfApiMethods
{
    private readonly string apiPath;
    private readonly string apiPublicKey;
    private readonly string apiPrivateKey;
    private readonly bool checkCertificate;

    public CfApiMethods(string apiPath, string apiPublicKey, string apiPrivateKey, bool checkCertificate)
    {
        this.apiPath = apiPath;
        this.apiPublicKey = apiPublicKey;
        this.apiPrivateKey = apiPrivateKey;
        this.checkCertificate = checkCertificate;

        // TLS 1.2+ Supported 
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    }

    public CfApiMethods(string apiPath, bool checkCertificate) : this(apiPath, null, null, checkCertificate) { }
}
