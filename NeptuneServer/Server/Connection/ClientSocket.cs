using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NeptuneServer.Communication;
using NeptuneServer.Communication.Incoming;
using NeptuneServer.Communication.Outgoing.Packets;
using NeptuneServer.Neptune.Client;

namespace NeptuneServer.Server.Connection
{
    public class ClientSocket
    {
        private Socket _clientSocket;
        private byte[] data;
        public Client Client;

        public ClientSocket(Socket clientSocket)
        {
            this._clientSocket = clientSocket;
            this.data = new byte[1024];
            this.Client = null;

            this.Recieve();
        }

        public bool IsAuthenticated
        {
            get
            {
                return this.Client != null && this.Client.User != null && this.Client.Application != null;
            }
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

                    //Console.WriteLine("Packet ID [" + header + "] Recieved!");
                    
                    if (!this.IsAuthenticated && header != IncomingPacketHeaders.AuthenticationRequestEvent)
                    {
                        AuthenticationDeniedComposer packet = new AuthenticationDeniedComposer("Authentication Required");
                        this.Send(packet.Finalize());
                    }
                    else
                    {
                        if (NeptuneEnvironment.GetNeptuneEnvironment().CommunicationManager.GetPacket(header, out IPacket packet))
                        {
                            packet.ExecutePacket(this, clientPacket);
                            Console.WriteLine("Packet ID [" + header + "] Executed!");
                        }
                        else
                        {
                            Console.WriteLine("Packet ID [" + header + "] Not Found!");
                        }
                    }

                    this.Recieve();
                }
            }
            catch(Exception e)
            {
                this.Disconnect();
            }
        }

        public void Send(byte[] data)
        {
            try
            {
                this._clientSocket.Send(data, 0, data.Length, SocketFlags.None);
            }
            catch
            {
                this.Disconnect();
            }
        }

        private void Disconnect()
        {
            try
            {
                this._clientSocket.Shutdown(SocketShutdown.Both);
                this._clientSocket.Disconnect(false);
                this._clientSocket.Dispose();
            }
            catch
            {

            }

            NeptuneEnvironment.GetNeptuneEnvironment().ServerManager.ConnectionManager.RemoveActiveClient(this);
            Console.WriteLine("Client Disconnected");
        }
    }
}
