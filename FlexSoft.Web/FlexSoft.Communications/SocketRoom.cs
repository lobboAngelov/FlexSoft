using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

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
        }

        public void RemoveClient(ISocketClient socketClient)
        {
            var clientToRemove = ConnectedClients.FirstOrDefault(x => x.ClientId == socketClient.ClientId);
            ConnectedClients.Remove(clientToRemove);
        }

        public void SendAll(object obj)
        {
            if (obj == null)
            {
                return;
            }

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                foreach (var connectedClient in ConnectedClients)
                {
                    connectedClient.WebSocketConnection.Send(memoryStream.ToArray());
                }
            }
        }

        public void SendOthers(object obj, int senderId)
        {
            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                foreach (var socketClient in ConnectedClients.Where(x => x.ClientId != senderId))
                {
                    socketClient.WebSocketConnection.Send(memoryStream.ToArray());
                }
            }
        }
    }
}
