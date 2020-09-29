using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Hubs
{
    public class TestHub : Hub
    {
        public async Task SendUserGrants(string test)
        {
            await Clients.Others.SendAsync("SendUserGrants", test);
        }
    }
}
