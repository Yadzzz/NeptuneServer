using NeptuneServer.Communication.Outgoing.Packets;
using NeptuneServer.Neptune.Client.Applications;
using NeptuneServer.Neptune.Client.Organization;
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
            string organizationSid = clientPacket.ReadString();
            string organizationAuthToken = clientPacket.ReadString();
            int applicationId = clientPacket.ReadInt();

            if (UsersFactory.TryGetUser(sid, authToken, out User user))
            {
                if (OrganizationFactory.TryGetOrganization(organizationSid, organizationAuthToken, out Organization organization))
                {
                    if (OrganizationFactory.IsAllowedUser(user.Id, organization.Id))
                    {
                        if (ApplicationFactory.TryGetApplication(applicationId, organization.Id, out Neptune.Client.Applications.Application application))
                        {
                            clientSocket.Client = new Neptune.Client.Client(user, application, organization);

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
                        AuthenticationDeniedComposer packet = new AuthenticationDeniedComposer("Not allowed User");
                        clientSocket.Send(packet.Finalize());
                    }
                }
                else
                {
                    AuthenticationDeniedComposer packet = new AuthenticationDeniedComposer("Organization Authentication Failed");
                    clientSocket.Send(packet.Finalize());
                }
            }
            else
            {
                AuthenticationDeniedComposer packet = new AuthenticationDeniedComposer("Authentication Failed");
                clientSocket.Send(packet.Finalize());
            }
        }
    }
}
