using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apicoreapp.Models
{
    public class Monitor
    {
        public bool Online { get; set; }
        public string Motd { get; set; }
        public string Error { get; set; }
        public Players Players { get; set; }
        




        /* 
         status       : success
online       : True
motd         : A Minecraft Server Powered by Docker
error        :
players      : @{max=20; now=0}
server       : @{name=1.12.2; protocol=340}
last_online  : 1529384898
last_updated : 1529384898
duration     : 436821122 
         */
    }

    public class Players
    {
        public int Max { get; set; }
        public int Now { get; set; }

    }
}
