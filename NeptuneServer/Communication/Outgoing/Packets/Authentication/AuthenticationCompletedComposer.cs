﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Communication.Outgoing.Packets
{
    public class AuthenticationCompletedComposer : ServerPacket
    {
        public AuthenticationCompletedComposer() : base(OutgoingPacketHeaders.AuthenticationComplete)
        {

        }
    }
}
