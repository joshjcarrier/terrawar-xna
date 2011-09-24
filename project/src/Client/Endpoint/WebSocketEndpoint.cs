
namespace Terrawar.Client.Endpoint
{
    using System.Threading;
    using SuperWebSocket.Client;

    public class WebSocketEndpoint
    {

        AutoResetEvent m_OpenEvent = new AutoResetEvent(false);

        public WebSocketEndpoint()
        {
            var websocket = new WebSocket("ws://24.87.140.2:4000/", "basic");
            
            websocket.OnOpen += (sender, args) =>
                                    {
                                        m_OpenEvent.Set();
                return;
            };
            websocket.OnClose += (sender, args) =>
            {
                return;
            };
            websocket.OnMessage += (sender, args) =>
                                       {
                                           return;
                                       };

            websocket.Connect();

            m_OpenEvent.WaitOne(1000);
            websocket.Send("authenticate a b c");
        }
    }
}
