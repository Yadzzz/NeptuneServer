using NeptuneServer.Neptune.Client.Applications.Logging;
using NeptuneServer.Server.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Communication.Incoming.Packets.Application
{
    public class ApplicationLogEvent : IPacket
    {
        public void ExecutePacket(ClientSocket clientSocket, ClientPacket packet)
        {
            string logType = packet.ReadString();
            string logText = packet.ReadString();
            string logDate = packet.ReadString();

            Log log = LoggingFactory.CreateLog(logType, logText, logDate);

            clientSocket.Client.Application.Log(log);
        }
    }
}
