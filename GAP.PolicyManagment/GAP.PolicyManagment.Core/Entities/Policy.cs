using System;
using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Entities
{
    public class Policy
    {
        public int PolicyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }        

        public DateTime StartDate { get; set; }

        public int CoverageTime { get; set; }

        public double Price { get; set; }

        public RiskType RiskType { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        
    }
}
