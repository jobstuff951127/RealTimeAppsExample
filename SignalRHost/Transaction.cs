using System.Collections.Generic;

namespace SignalRHost
{
    public class Transaction
    {
        public string ConnectionId { get; set; }
        public int BusinessId { get; set; }

        public static List<Transaction> ConnectedClients = new List<Transaction>();
    }
}
