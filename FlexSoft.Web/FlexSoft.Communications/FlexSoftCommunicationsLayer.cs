using System;
using System.Collections.Concurrent;
using Fleck;

namespace FlexSoft.Communications
{
    public class FlexSoftCommunicationsLayer : ITrainingServerCommunicationLayer
    {
        private readonly IWebSocketServer _webSocketServer;
        private readonly ConcurrentDictionary<IWebSocketConnection, ISocketClient> _joinedClients;

        public FlexSoftCommunicationsLayer(IWebSocketServer webSocketServer,
            ConcurrentDictionary<IWebSocketConnection, ISocketClient> joinedClients)
        {
            _webSocketServer = webSocketServer;
            _joinedClients = joinedClients;

            _webSocketServer.Start(connection =>
            {
                connection.OnOpen = () => SocketClientOpened(connection);
                connection.OnBinary = data => SocketMessage(connection,data);
                connection.OnClose = () => SocketClientClosed(connection);
                connection.OnMessage = message => connection.Send(message);
            });
        }

        public void SocketClientClosed(IWebSocketConnection connection)
        {
            throw new NotImplementedException();
        }

        public void SocketClientOpened(IWebSocketConnection connection)
        {
            var clientInfo = _joinedClients[connection].ToString();
            Console.WriteLine($"Client connected: {clientInfo}");
        }

        public void SocketMessage(IWebSocketConnection connection, byte[] data)
        {
            if (_joinedClients.ContainsKey(connection))
            {

            }
            else
            {
                
            }
        }

        public void StartServerClientSocket()
        {
            throw new NotImplementedException();
        }

        public void WebSocketHandlerSetUp(IWebSocketConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
