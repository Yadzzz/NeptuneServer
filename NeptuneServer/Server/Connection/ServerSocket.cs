﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Server.Connection
{
    public class ServerSocket
    {
        private Socket _server;

        public ServerSocket()
        {
            this._server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this._server.Bind(new IPEndPoint(IPAddress.Any, 30000));
            this._server.Listen(NeptuneConfiguration.MaxSocketConnection);

            this.BeginAccept();
        }

        private void BeginAccept()
        {
            try
            {
                this.CheckSocketState();
                this._server.BeginAccept(this.EndAccept, this._server);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void EndAccept(IAsyncResult result)
        {
            if (result == null)
            {
                this.BeginAccept();
                return;
            }

            try
            {
                Socket client = this._server.EndAccept(result);
                NeptuneEnvironment.GetNeptuneEnvironment().ServerManager.ConnectionManager.AddActiveClient(new ClientSocket(client));
                Console.WriteLine("Connection Accepted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            this.BeginAccept();
        }

        private void CheckSocketState()
        {
            //Check if Socket is broken for some reason
        }
    }
}
