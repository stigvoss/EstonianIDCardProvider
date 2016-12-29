using KeePass.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstonianIDCardProvider
{
    public sealed class EstonianIDCardProviderExt : Plugin
    {
        private IPluginHost _host = null;
        private SmartCardProvider _provider = new SmartCardProvider();

        public override bool Initialize(IPluginHost host)
        {
            _host = host;
            _host.KeyProviderPool.Add(_provider);

            return true;
        }

        public override void Terminate()
        {
            _host.KeyProviderPool.Remove(_provider);
        }
    }
}
