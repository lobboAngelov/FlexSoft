using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fleck;

namespace FlexSoft.Communications
{
    public class ArduinoSocketClient : ISocketClient
    {
        public ArduinoSocketClient(SocketRoom socketRoom, IWebSocketConnection webSocketConnection, int clientId)
        {
            SocketRoom = socketRoom;
            WebSocketConnection = webSocketConnection;
            ClientId = clientId;
        }

        public SocketRoom SocketRoom { get; }
        public IWebSocketConnection WebSocketConnection { get; }
        public int ClientId { get; }

        public override string ToString()
        {
            return $"Arduino client {ClientId}, {WebSocketConnection.ConnectionInfo.ClientIpAddress}";
        }
    }
}
