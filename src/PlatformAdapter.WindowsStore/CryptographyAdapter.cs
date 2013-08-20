using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Security.Cryptography.Core;

namespace PlatformAdapter.WindowsStore
{
    internal class CryptographyAdapter : ICryptographyAdapter
    {
        private const string HmacSha256AlgorithmName = "HMAC_SHA256";

        public string Encrypt(string secretKey, string message)
        {
            // TODO create encryption algoriythm
            MacAlgorithmProvider provider = MacAlgorithmProvider.OpenAlgorithm(HmacSha256AlgorithmName);
            var key = provider.CreateKey(Convert.FromBase64String(secretKey).AsBuffer());

            byte[] data = Encoding.UTF8.GetBytes(message);
            var hashed = CryptographicEngine.Encrypt(key, data.AsBuffer(), null);
            return Convert.ToBase64String(hashed.ToArray());
        }

        public string Decrypt(string secretKey, string message)
        {
            // TODO create decryption algoriythm
            MacAlgorithmProvider provider = MacAlgorithmProvider.OpenAlgorithm(HmacSha256AlgorithmName);
            var key = provider.CreateKey(Convert.FromBase64String(secretKey).AsBuffer());

            byte[] data = Encoding.UTF8.GetBytes(message);
            var hashed = CryptographicEngine.Decrypt(key, data.AsBuffer(), null);
            return Convert.ToBase64String(hashed.ToArray());
        }

        public void Initialize()
        {
        }

        public void Teardown()
        {
        }
    }
}
