using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NeptuneServer.Communication;
using NeptuneServer.Communication.Incoming;

namespace NeptuneServer.Server.Connection
{
    public class ClientSocket
    {
        private Socket _clientSocket;
        private byte[] data;

        public ClientSocket(Socket clientSocket)
        {
            this._clientSocket = clientSocket;
            this.data = new byte[1024];
            this.Recieve();
        }

        private void Recieve()
        {
            try
            {
                this._clientSocket.BeginReceive(this.data, 0, this.data.Length, SocketFlags.None, this.Recieved, this._clientSocket);
            }
            catch
            {
                this.Disconnect();
            }
        }

        private void Recieved(IAsyncResult result)
        {
            try
            {
                int bytesRecieved = this._clientSocket.EndReceive(result);

                if (bytesRecieved > 0)
                {
                    byte[] newBytes = new byte[bytesRecieved];
                    Array.Copy(this.data, newBytes, bytesRecieved);
                    int header = BitConverter.ToInt32(newBytes, 0);
                    ClientPacket clientPacket = new ClientPacket(newBytes, header);

                    Console.WriteLine("Packet ID [" + header + "] Recieved!");

                    if (NeptuneEnvironment.GetNeptuneEnvironment().CommunicationManager.GetPacket(header, out IPacket packet))
                    {
                        packet.ExecutePacket(this, clientPacket);
                        Console.WriteLine("Packet ID [" + header + "] Executed!");
                    }
                    else
                    {
                        Console.WriteLine("Packet ID [" + header + "] Not Found!");
                    }

                    this.Recieve();
                }
            }
            catch
            {
                this.Disconnect();
            }
        }

        private void Disconnect()
        {
            this._clientSocket.Shutdown(SocketShutdown.Both);
            this._clientSocket.Disconnect(false);
            this._clientSocket.Dispose();

            Console.WriteLine("Client Disconnected");
        }
    }
}
