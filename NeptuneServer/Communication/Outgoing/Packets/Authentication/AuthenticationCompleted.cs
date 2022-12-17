using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Communication.Outgoing.Packets
{
    public class AuthenticationCompleted : ServerPacket
    {
        public AuthenticationCompleted() : base(OutgoingPacketHeaders.AuthenticationComplete)
        {

        }
    }
}
