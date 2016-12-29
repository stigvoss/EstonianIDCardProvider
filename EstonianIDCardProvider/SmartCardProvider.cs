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

        public override byte[] GetKey(KeyProviderQueryContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
