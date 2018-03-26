using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fleck;

namespace FlexSoft.Communications
{
    public class BrowserSocketClient : ISocketClient
    {
        public BrowserSocketClient(SocketRoom socketRoom, IWebSocketConnection webSocketConnection)
        {
            SocketRoom = socketRoom;
            WebSocketConnection = webSocketConnection;
        }

        public SocketRoom SocketRoom { get; }
        public IWebSocketConnection WebSocketConnection { get; }
        public int ClientId { get; set; }

        public override string ToString()
        {
            return $"Web client {ClientId}, {WebSocketConnection.ConnectionInfo.ClientIpAddress}";
        }
    }
}
