using Fleck;

namespace FlexSoft.Communications
{
    public interface ITrainingServerCommunicationLayer
    {
        void StartServerClientSocket();
        void SocketClientOpened(IWebSocketConnection connection);
        void SocketClientClosed(IWebSocketConnection connection);
        void SocketMessage(IWebSocketConnection connection, byte[] data);
        void WebSocketHandlerSetUp(IWebSocketConnection connection);
    }
}