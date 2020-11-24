using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost
{
    public class UserDetail
    {
        public string ConnectionId { get; set; }
        public int UserName { get; set; }

        public static List<UserDetail> ConnectedUsers = new List<UserDetail>();


        public static List<UserDetail> Test(string id, int idVenta)
        {
            List<UserDetail> lst = new List<UserDetail>
            {
                new UserDetail { ConnectionId = id, UserName = idVenta }
            };
            return lst;
        }
    }
}
