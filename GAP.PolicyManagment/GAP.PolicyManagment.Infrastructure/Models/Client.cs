using System.Collections.Generic;

namespace GAP.PolicyManagment.Infrastructure.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PolicyClient> PolicyClients { get; set; }

    }
}
