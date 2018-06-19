using System.Collections.Generic;

namespace apicoreapp.Models
{
    public class Tenant
    {
        public string Name { get; set; }
        public IEnumerable<Endpoint> Endpoints{ get; set; }    
    }
}
