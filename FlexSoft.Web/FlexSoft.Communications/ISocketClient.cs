using Fleck;

namespace FlexSoft.Communications
{
    public interface ISocketClient
    {
        SocketRoom SocketRoom { get; }
        IWebSocketConnection WebSocketConnection { get; }
        int RfIdCardNumber { get; }
    }
}