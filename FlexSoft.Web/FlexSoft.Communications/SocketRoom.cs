using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Google.Protobuf;

namespace FlexSoft.Communications
{
    public class SocketRoom
    {
        public IList<ISocketClient> ConnectedClients { get; }

        public SocketRoom()
        {
            ConnectedClients = new List<ISocketClient>();
        }

        public void AddClient(ISocketClient socketClient)
        {
            ConnectedClients.Add(socketClient);
            Console.WriteLine($@"New connection: {socketClient}");
        }

        public void RemoveClient(ISocketClient socketClient)
        {
            var clientToRemove = ConnectedClients.FirstOrDefault(x => x.RfIdCardNumber == socketClient.RfIdCardNumber);
            ConnectedClients.Remove(clientToRemove);
        }

        public void SendAll(ServerMessage srvMessage)
        {
            foreach (var connectedClient in ConnectedClients)
            {
                connectedClient.WebSocketConnection.Send(srvMessage.ToByteArray());
            }
        }

        public void SendToArduino(ServerMessage serverMessage)
        {
            foreach (var socketClient in ConnectedClients.Where(x => x is ArduinoSocketClient))
            {
                socketClient.WebSocketConnection.Send(serverMessage.ToByteArray());
            }
        }

        public void SendToWebClient(ServerMessage serverMessage)
        {
            foreach (var socketClient in ConnectedClients.Where(x => x is BrowserSocketClient))
            {
                socketClient.WebSocketConnection.Send(serverMessage.ToByteArray());
            }
        }
    }
}
