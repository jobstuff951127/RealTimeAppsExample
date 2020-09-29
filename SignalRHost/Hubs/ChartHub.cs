using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Hubs
{
    public class ChartHub : Hub
    {
        public async Task SendUserCharts(ArrayList test, ArrayList test1)
        {
            await Clients.Others.SendAsync("SendUserCharts", test, test1);
        }
    }
}
