using System;
using System.Security.Cryptography;

namespace EstonianIDCardProvider
{
    public class Encryption : IDisposable
    {
        private const string CSP_PROVIDER = "Microsoft Base Smart Card Crypto Provider";
        private const int CSP_TYPE = 1;
        private const CspProviderFlags CSP_FLAGS_PARAMETERS = CspProviderFlags.UseDefaultKeyContainer;

        private const bool USE_OAEP = false;

        RSACryptoServiceProvider _provider;

        public Encryption()
        {
            CspParameters parameters = new CspParameters(CSP_TYPE, CSP_PROVIDER)
            {
                Flags = CSP_FLAGS_PARAMETERS
            };
            _provider = new RSACryptoServiceProvider(parameters);
        }

        public byte[] EncryptKey(byte[] key)
        {
            return _provider.Encrypt(key, USE_OAEP);
        }

        public byte[] DecryptKey(byte[] encryptedKey)
        {
            return _provider.Decrypt(encryptedKey, USE_OAEP);
        }
        public void Dispose()
        {
            _provider.Dispose();
        }
    }
}