using Microsoft.AspNetCore.SignalR;
using OnlineChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineChatApp.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(Message message) =>
            await Clients.All.SendAsync("ReseveMessage", message);
    }
}
