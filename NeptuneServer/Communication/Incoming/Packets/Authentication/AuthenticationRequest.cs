using NeptuneServer.Server.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Communication.Incoming.Packets
{
    public class AuthenticationRequest : IPacket
    {
        public void ExecutePacket(ClientSocket clientSocket, ClientPacket clientPacket)
        {
            string authToken = clientPacket.ReadString();
            string applicationId = clientPacket.ReadString();

            Console.WriteLine(authToken);
            Console.WriteLine(applicationId);
        }
    }
}
