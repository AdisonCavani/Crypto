using Crypto.Core;
using Microsoft.Extensions.Configuration;

namespace Crypto;

public class ApiTest
{
  static void Main(string[] args)
  {
    var configuration = new ConfigurationBuilder()
    .AddUserSecrets<ApiTest>()
    .Build();

    var pm = new PublicMethods(configuration["API:Path"], Convert.ToBoolean(configuration["API:CheckCertificate"]));
    var ppm = new PrivateMethods(configuration["API:Path"], configuration["API:PublicKey"], configuration["API:PrivateKey"], Convert.ToBoolean(configuration["API:CheckCertificate"]));

    Console.WriteLine(pm.GetServerTime());
  }
}
