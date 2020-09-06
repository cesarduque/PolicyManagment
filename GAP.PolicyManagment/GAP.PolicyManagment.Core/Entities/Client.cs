using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Entities
{
    public class Client
    {       
        public int ClientId { get; set; }

        public string Name { get; set; }

        public ICollection<Policy> Policies { get; set; }
    }
}
