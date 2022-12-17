using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Communication.Outgoing.Packets
{
    public class AuthenticationDenied : ServerPacket
    {
        public AuthenticationDenied(string error) : base(OutgoingPacketHeaders.AuthenticationDenied)
        {
            base.WriteString(error);
        }
    }
}
