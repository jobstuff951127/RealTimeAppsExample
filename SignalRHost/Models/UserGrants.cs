using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Models
{
    public class UserGrants
    {
        public int IdGrant { get; set; }
        public int IdUser { get; set; }
        public string Modulo { get; set; }
        public bool Access { get; set; }
    }
}
