using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using WebSocketManager;

namespace Chat
{
    public class ChatHandler : WebSocketHandler
    {
        public ChatHandler(WebSocketConnectionManager maneger) : base(maneger) { }

        public async Task SendMessage(string socketId, string message) =>
            await InvokeClientMethodToAllAsync("SendMessage", socketId, message);

    }
}
