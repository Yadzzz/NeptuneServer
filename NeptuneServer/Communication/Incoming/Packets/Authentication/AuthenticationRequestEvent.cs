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
            string sid = clientPacket.ReadString();
            string authToken = clientPacket.ReadString();
            int applicationId = clientPacket.ReadInt();

            if (UsersFactory.TryGetUser(sid, authToken, out User user))
            {
                if (Neptune.Applications.ApplicationFactory.TryGetApplication(applicationId, user.Id, out Neptune.Applications.Application application))
                {
                    clientSocket.Client = new Neptune.Client.Client(user, application);

                    AuthenticationCompletedComposer packet = new AuthenticationCompletedComposer();
                    clientSocket.Send(packet.Finalize());
                }
                else
                {
                    AuthenticationDeniedComposer packet = new AuthenticationDeniedComposer("Invalid Application ID");
                    clientSocket.Send(packet.Finalize());
                }
            }
            else
            {
                AuthenticationDeniedComposer packet = new AuthenticationDeniedComposer("Authentication Token Not Valid");
                clientSocket.Send(packet.Finalize());
            }
        }
    }
}
