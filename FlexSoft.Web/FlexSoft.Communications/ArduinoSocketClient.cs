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
        public ArduinoSocketClient(SocketRoom socketRoom, IWebSocketConnection webSocketConnection, int rfId)
        {
            SocketRoom = socketRoom;
            WebSocketConnection = webSocketConnection;
            RfIdCardNumber = rfId;
        }

        public SocketRoom SocketRoom { get; }
        public IWebSocketConnection WebSocketConnection { get; }
        public int RfIdCardNumber { get; }

        public override string ToString()
        {
            return $"Arduino client {RfIdCardNumber}, {WebSocketConnection.ConnectionInfo.ClientIpAddress}";
        }
    }
}
