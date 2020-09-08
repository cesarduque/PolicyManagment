using System.Collections.Generic;

namespace GAP.PolicyManagment.Infrastructure.Models
{
    public class RiskType
    {
        public int RiskTypeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
        
    }
}
