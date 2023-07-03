using NeptuneServer.Communication.Outgoing.Packets;
using NeptuneServer.Neptune.Client.Users;
using NeptuneServer.Server.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Communication.Incoming.Packets
{
    public class AuthenticationRequestEvent : IPacket
    {
        public void ExecutePacket(ClientSocket clientSocket, ClientPacket clientPacket)
        {
            string authToken = clientPacket.ReadString();

            if (UsersFactory.TryGetUser(authToken, out User user))
            {
                    clientSocket.Client = new Neptune.Client.Client(user);

                    AuthenticationCompletedComposer packet = new AuthenticationCompletedComposer();
                    clientSocket.Send(packet.Finalize());
            }
            else
            {
                AuthenticationDeniedComposer packet = new AuthenticationDeniedComposer("Authentication Token Not Valid");
                clientSocket.Send(packet.Finalize());
            }
        }
    }
}
