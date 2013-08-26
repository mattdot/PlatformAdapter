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

        #region IDisposable

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~CryptographyAdapter()
        {
            this.Dispose(false);
        }

        protected bool IsDisposed { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.IsDisposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                }

                //dispose unmanaged resources

                this.IsDisposed = true;
            }
        }

        #endregion
    }
}
