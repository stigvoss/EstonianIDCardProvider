using KeePassLib.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstonianIDCardProvider
{
    public sealed class SmartCardProvider : KeyProvider
    {
        private const string PROVIDER_NAME = "Estonian ID Card Provider";

        public override string Name
        {
            get
            {
                return PROVIDER_NAME;
            }
        }

        public override byte[] GetKey(KeyProviderQueryContext context)
        {
            byte[] key, encryptedKey;
            string databaseFilePath = context.DatabaseIOInfo.Path;
            
            using (KeyFileAccess fileAccess = new KeyFileAccess(databaseFilePath))
            using (KeyGenerator keyGenerator = new KeyGenerator())
            using (Encryption encryption = new Encryption())
            {
                if (context.CreatingNewKey)
                {
                    fileAccess.Create();
                    key = keyGenerator.GenerateKey();
                    encryptedKey = encryption.EncryptKey(key);
                    fileAccess.Write(encryptedKey);
                }
                else
                {
                    fileAccess.Open();
                }

                encryptedKey = fileAccess.Read();
                key = encryption.DecryptKey(encryptedKey);
            }

            return key;
        }
    }
}
