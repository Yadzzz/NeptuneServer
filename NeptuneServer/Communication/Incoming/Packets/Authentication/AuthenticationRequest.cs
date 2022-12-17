using NeptuneServer.Communication.Outgoing.Packets;
using NeptuneServer.Neptune.Applications;
using NeptuneServer.Neptune.Client.Users;
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
            int applicationId = clientPacket.ReadInt();

            if (UsersFactory.TryGetUser(authToken, out User user))
            {
                if (ApplicationFactory.TryGetApplication(applicationId, user.Id, out Application application))
                {
                    clientSocket.Client = new Neptune.Client.Client(user, application);

                    AuthenticationCompleted packet = new AuthenticationCompleted();
                    clientSocket.Send(packet.Finalize());

                    Console.WriteLine("OWNER OF APPLICATION");
                }
                else
                {
                    AuthenticationDenied packet = new AuthenticationDenied("Invalid Application ID");
                    clientSocket.Send(packet.Finalize());

                    Console.WriteLine("NOT OWNER OF APPLICATION");
                }
            }
            else
            {
                AuthenticationDenied packet = new AuthenticationDenied("Authentication Token Not Valid");
                clientSocket.Send(packet.Finalize());

                Console.WriteLine("NOT AUTH");
            }
        }
    }
}
