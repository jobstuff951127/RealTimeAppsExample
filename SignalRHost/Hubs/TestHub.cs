using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Hubs
{
    public class TestHub : Hub
    {
        //public HubConnectionContext Clients { get; set; }
        //public HubCallerContext Context { get; set; }
        //public IGroupManager Groups { get; set; }

        public async Task SendUserGrants(string test)
        {
            await Clients.Others.SendAsync("SendUserGrants", test, 123);
        }

        //public void SendPrivateMessage(string toUserId, string message)
        //{

        //    string fromUserId = Context.ConnectionId;

        //    var toUser = OnlineUsers .FirstOrDefault(x => x.ConnectionId == toUserId);
        //    var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

        //    if (toUser != null && fromUser != null)
        //    {
        //        // send to
        //        Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message);

        //        // send to caller user
        //        Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);
        //    }

        //}
    }
}
