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
        public BrowserSocketClient(SocketRoom socketRoom, IWebSocketConnection webSocketConnection, int clientId)
        {
            SocketRoom = socketRoom;
            WebSocketConnection = webSocketConnection;
            RfIdCardNumber = clientId;
        }

        public SocketRoom SocketRoom { get; }
        public IWebSocketConnection WebSocketConnection { get; }
        public int RfIdCardNumber { get;}

        public override string ToString()
        {
            return $"Web client {RfIdCardNumber}, {WebSocketConnection.ConnectionInfo.ClientIpAddress}";
        }
    }
}
