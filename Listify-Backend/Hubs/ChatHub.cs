using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Listify_Backend.Hubs
{
    public class ChatHub : Hub
    {



        public async Task SendPlaylist(string playlist)
        {
            await Clients.All.SendAsync("SendMethod", playlist);
        }
    }
}
