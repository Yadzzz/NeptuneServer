using NeptuneServer.Communication.Incoming;
using NeptuneServer.Server.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Communication
{
    public interface IPacket
    {
        void ExecutePacket(ClientSocket clientSocket, ClientPacket packet);
    }
}
