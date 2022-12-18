using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeptuneServer.Server.Connection;
using NeptuneServer.Server.Database;
using NeptuneServer.Server.Logger;

namespace NeptuneServer.Server
{
    public class ServerManager
    {
        public ConnectionManager ConnectionManager { get; set; }
        public DatabaseManager DatabaseManager { get; set; }
        public LoggerManager LoggerManager { get; set; }

        public ServerManager()
        {
            this.ConnectionManager = new ConnectionManager();
            this.DatabaseManager = new DatabaseManager();
            this.LoggerManager = new LoggerManager(new LoggerConfiguration
            {
                ConsoleLoggerEnabled = true,
                FileLoggerEnabled = false,
                DatabaseLoggerEnabled = false,
            });

            Console.WriteLine("ServerManager Initialized ->");
        }
    }
}
