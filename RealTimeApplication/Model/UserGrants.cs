using System;
using System.Collections.Generic;
using System.Text;

namespace RealTimeApplication.Model
{
    class UserGrants
    {
        public int IdGrant { get; set; }
        public int IdUser { get; set; }
        public string Modulo { get; set; }
        public bool Access { get; set; }
    }
}
