using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeptuneServer.Server;
using NeptuneServer.Communication;
using NeptuneServer.Neptune.Client;

namespace NeptuneServer
{
    public class NeptuneEnvironment
    {
        public ServerManager ServerManager { get; set; }
        public CommunicationManager CommunicationManager { get; set; }
        public ClientManager ClientManager { get; set; }

        public void Initialize()
        {
            this.ServerManager = new ServerManager();
            this.CommunicationManager = new CommunicationManager();
            this.ClientManager = new ClientManager();

            Console.WriteLine("Neptune Initialized ->");
            Console.WriteLine();
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
