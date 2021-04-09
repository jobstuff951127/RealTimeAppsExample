using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Hubs
{
    public class TotalPOSHub : Hub
    {
        //The caller is the one who send data through the SignalR method 
        //The receiver is the one whos listening the SignalR method
        public async Task SendUserCharts(ArrayList test, ArrayList test1)
        {
            //This line send the response to everyone but the caller
            await Clients.Others.SendAsync("SendUserCharts", test, test1);
        }

        public async Task Done(bool done, int id)
        {
            try
            {
                //Get SignalR id from the caller
                string fromUserId = Context.ConnectionId;
                //Get the SignalR id from the client/receiver that has the same business id but different signalR id that the actual caller
                var toUser = Transaction.ConnectedClients.FirstOrDefault(x => x.BusinessId == id && x.ConnectionId != fromUserId);

                //Send to a specific client/receiver the message from the caller
                if (toUser != null)
                    await Clients.Client(toUser.ConnectionId).SendAsync("Done", done, id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void Connect(int BusinessId)
        {
            //Get SignalR id from the caller
            var id = Context.ConnectionId;

            //If client/receiver is not registered already          
            if (!Transaction.ConnectedClients.Any(x => x.ConnectionId == id))
            {
                //This lines register SignalR native connection id and the business id while binding them to track caller and reciever
                Transaction.ConnectedClients.Add(new Transaction
                {
                    ConnectionId = id,
                    BusinessId = BusinessId
                });
            }
        }

        public void UnSubscribe()
        {
            try
            {
                var id = Context.ConnectionId;

                if (Transaction.ConnectedClients.Any(c => c.ConnectionId == id))
                {
                    Transaction.ConnectedClients.Remove(Transaction.ConnectedClients.First(c => c.ConnectionId == id));
                    Context.Abort();
                }
                //Transaction.ConnectedClients.FindAll(x => x.ConnectionId == id)
                //    .ForEach(c => Transaction.ConnectedClients.Remove(c));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

