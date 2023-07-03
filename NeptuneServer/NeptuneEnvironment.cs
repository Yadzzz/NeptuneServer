using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeptuneServer.Server;
using NeptuneServer.Communication;

namespace NeptuneServer
{
    public class NeptuneEnvironment
    {
        public ServerManager ServerManager { get; set; }
        public CommunicationManager CommunicationManager { get; set; }

        public void Initialize()
        {
            this.ServerManager = new ServerManager();
            this.CommunicationManager = new CommunicationManager();

            Console.WriteLine("Neptune Server Initialized ->");
        }

        private static NeptuneEnvironment _neptuneEnvironment;

        public static NeptuneEnvironment GetNeptuneEnvironment()
        {
            //_neptuneEnvironment ??= new NeptuneEnvironment();

            if (_neptuneEnvironment == null)
            {
                _neptuneEnvironment = new NeptuneEnvironment();
            }

            return _neptuneEnvironment;
        }
    }
}
