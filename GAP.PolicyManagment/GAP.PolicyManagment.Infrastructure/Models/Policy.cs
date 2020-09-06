using System;
using System.Collections.Generic;

namespace GAP.PolicyManagment.Infrastructure.Models
{
    public class Policy
    {
        public Policy()
        {
            this.Clients = new HashSet<Client>();
            this.CoverageTypes = new HashSet<CoverageType>();
        }

        public int PolicyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }                

        public DateTime StartDate { get; set; }

        public int CoverageTime { get; set; }

        public double Price { get; set; }

        public RiskType RiskType { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public virtual ICollection<CoverageType> CoverageTypes { get; set; }
    }
}
