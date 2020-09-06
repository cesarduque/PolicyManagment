using System.Collections.Generic;

namespace GAP.PolicyManagment.Infrastructure.Models
{
    public class Client
    {
        public Client()
        {
            this.Policies = new HashSet<Policy>();
        }

        public int ClientId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
