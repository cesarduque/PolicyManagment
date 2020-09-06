using System.Collections.Generic;

namespace GAP.PolicyManagment.Infrastructure.Models
{
    public class CoverageType
    {
        public CoverageType ()
        {
            this.Policies = new HashSet<Policy>();            
        }

        public int CoverageTypeId { get; set; }

        public string Name { get; set; }

        public int CovergePercentage { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
