﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeptuneServer.Communication.Outgoing;
using NeptuneServer.Communication.Incoming;
using NeptuneServer.Communication.Incoming.Packets;
using NeptuneServer.Communication.Incoming.Packets.Application;

namespace NeptuneServer.Communication
{
    public class CommunicationManager
    {
        public Dictionary<int, IPacket> Packets;

        public CommunicationManager()
        {
            this.Packets = new Dictionary<int, IPacket>();
            this.LoadPackets();

            Console.WriteLine("CommunicationManager Initialized ->");
        }

        public bool GetPacket(int header, out IPacket packet)
        {
            return this.Packets.TryGetValue(header, out packet);
        }

        public void LoadPackets()
        {
            this.Packets.Add(IncomingPacketHeaders.AuthenticationRequestEvent, new AuthenticationRequestEvent());
            this.Packets.Add(IncomingPacketHeaders.ApplicationLogEvent, new ApplicationLogEvent());
        }
    }
}
