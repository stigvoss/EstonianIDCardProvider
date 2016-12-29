using System;
using System.Security.Cryptography;

namespace EstonianIDCardProvider
{
    public class KeyGenerator : IDisposable
    {
        private const int SIZE_GENERATED_KEY = 128;

        RNGCryptoServiceProvider _provider;

        public KeyGenerator()
        {
            _provider = new RNGCryptoServiceProvider();
        }

        public byte[] GenerateKey()
        {
            byte[] key = new byte[SIZE_GENERATED_KEY];

            _provider.GetBytes(key);

            return key;
        }

        public void Dispose()
        {
            _provider.Dispose();
        }
    }
}