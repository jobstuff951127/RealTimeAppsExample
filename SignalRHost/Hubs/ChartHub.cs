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
            //This line send the response to everyone but the caller
            await Clients.Others.SendAsync("SendUserCharts", test, test1);
        }

        public async Task Done(bool done, int id) 
        {
            //Get SignalR id from the caller
            string fromUserId = Context.ConnectionId;
            //Get the SignalR id from the client that has the same business id but different signalR id that the actual caller
            var toUser = UserDetail.ConnectedUsers.FirstOrDefault(x => x.UserName == id && x.ConnectionId != fromUserId);

            //Send to a specific client the response from the caller
            if(toUser != null)
                await Clients.Client(toUser.ConnectionId).SendAsync("Done", done, id);
    
            //Junk that maybe useful
            //var caller = Clients.Caller.SendAsync("Done", , done); // Others.SendAsync("Done", id, done);
        }
        public void Connect(int userName)
        {
            //Get SignalR id from the caller
            var id = Context.ConnectionId;

            //If client is not registered already          
            if (UserDetail.ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                //This lines register SignalR native connection id and the business id while binding them to track caller and reciever
                UserDetail.ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserName = userName });

                //Junk that maybe useful
                //// send to caller
                //Clients.Caller.SendAsync("Connect", id, userName, UserDetail.ConnectedUsers);
                //// send to all except caller client
                //Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }

        public void OnDisconnect()
        {
            var id = Context.ConnectionId;

            if (UserDetail.ConnectedUsers.Count(x => x.ConnectionId == id) == 1)
            {
                var obj = UserDetail.ConnectedUsers.FirstOrDefault(x => x.ConnectionId == id);
                UserDetail.ConnectedUsers.Remove(obj);
            }
        }
    }
}

