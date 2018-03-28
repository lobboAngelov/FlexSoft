using System;
using System.Collections.Concurrent;
using System.Linq;
using Autofac;
using Fleck;
using FlexSoft.Infrastructure;
using FlexSoft.Infrastructure.Entites;
using Google.Protobuf;

namespace FlexSoft.Communications
{
    public class FlexSoftCommunicationsLayer : ITrainingServerCommunicationLayer
    {
        private readonly IWebSocketServer _webSocketServer;
        private readonly ConcurrentDictionary<IWebSocketConnection, ISocketClient> _joinedClients;
        private readonly ConcurrentBag<SocketRoom> _socketRooms;
        private readonly ILifetimeScope _lifetimeScope;

        public FlexSoftCommunicationsLayer(IWebSocketServer webSocketServer,
            ConcurrentDictionary<IWebSocketConnection, ISocketClient> joinedClients,
            ConcurrentBag<SocketRoom> socketRooms,
            ILifetimeScope lifetimeScope)
        {
            _webSocketServer = webSocketServer;
            _joinedClients = joinedClients;
            _socketRooms = socketRooms;
            _lifetimeScope = lifetimeScope;
        }

        public void SocketClientClosed(IWebSocketConnection connection)
        {
            _joinedClients.TryRemove(connection, out var client);
            client.SocketRoom.RemoveClient(client);
            Console.WriteLine($@"Client disconnected: {client}");
        }

        public void SocketClientOpened(IWebSocketConnection connection)
        {
            Console.WriteLine($@"New connection: {connection.ConnectionInfo.ClientIpAddress}");
        }

        public void SocketMessage(IWebSocketConnection connection, byte[] data)
        {
            if (_joinedClients.ContainsKey(connection))
            {
                var message = MessageFromClient.Parser.ParseFrom(data);

                switch (message.ClientType)
                {
                    case ClientType.ArduinoClient:
                        HandleArduinoMessage(message.ArduinoAction);
                        break;
                    case ClientType.WebClient:
                        HandleClientMessage(message.WebClientAction);
                        break;
                    default:
                        Console.WriteLine($@"Invalid client type message received {message.ClientType.ToString()}");
                        break;
                }
            }
            else
            {
                var message = MessageFromClient.Parser.ParseFrom(data);

                switch (message.ClientType)
                {
                    case ClientType.ArduinoClient:
                        AddArduinoToRoom(message.ArduinoAction.ArduinoJoin, connection);
                        break;
                    case ClientType.WebClient:
                        AddWebClientToRoom(message.WebClientAction.WebClientActionJoin, connection);
                        break;
                    default:
                        Console.WriteLine($@"Invalid client type message received {message.ClientType.ToString()}");
                        break;
                }
            }
        }

        private void HandleClientMessage(WebClientAction messageWebClientAction)
        {
            throw new NotImplementedException();
        }

        private void AddWebClientToRoom(WebClientActionJoin webClientActionJoin, IWebSocketConnection connection)
        {
            var room = _socketRooms.FirstOrDefault(x => x.ConnectedClients.Any(client => client.RfIdCardNumber == webClientActionJoin.RfIdCardNo));

            if (room == null)
            {
                room = new SocketRoom();
            }

            var newClient = new BrowserSocketClient(room, connection, webClientActionJoin.RfIdCardNo);
            room.AddClient(newClient);

            _joinedClients.TryAdd(connection, newClient);
        }

        private void AddArduinoToRoom(ArduinoJoin arduinoActionArduinoJoin, IWebSocketConnection connection)
        {
            var response = new ServerMessage();

            var repository = _lifetimeScope.Resolve<IRepository>();

            if (repository.GetAll<ArduinoDevice>()
                .Any(arduino => arduino.ArduinoDeviceId == arduinoActionArduinoJoin.ArduinoId))
            {
                response.ArduinoConnectedMessage = new ArduinoConnected
                {
                    Fail = true
                };
            }
            else
            {
                var room = _socketRooms
                    .FirstOrDefault(x => x.ConnectedClients
                    .Any(client => client.RfIdCardNumber == arduinoActionArduinoJoin.RfIdCard));

                if (room == null)
                {
                    room = new SocketRoom();
                }

                var newClient = new ArduinoSocketClient(room, connection, arduinoActionArduinoJoin.RfIdCard);
                room.AddClient(newClient);

                _joinedClients.TryAdd(connection, newClient);
            }

            connection.Send(response.ToByteArray());
        }

        private void HandleArduinoMessage(ArduinoAction messageArduinoAction)
        {
            throw new NotImplementedException();
        }

        public void StartServerClientSocket()
        {
            _webSocketServer.Start(connection =>
            {
                connection.OnOpen = () => SocketClientOpened(connection);
                connection.OnBinary = data => SocketMessage(connection, data);
                connection.OnClose = () => SocketClientClosed(connection);
                connection.OnMessage = message => connection.Send(message);
            }); ;
        }

        public void WebSocketHandlerSetUp(IWebSocketConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
