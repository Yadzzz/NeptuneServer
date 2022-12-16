using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeptuneServer.Server.Connection;

namespace NeptuneServer.Server
{
    public class ServerManager
    {
        public ConnectionManager ConnectionManager { get; set; }

        public ServerManager()
        {
            this.ConnectionManager = new ConnectionManager();
        }
    }
}
