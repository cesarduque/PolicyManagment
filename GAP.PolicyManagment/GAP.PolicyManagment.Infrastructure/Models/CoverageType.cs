using System.Collections.Generic;

namespace GAP.PolicyManagment.Infrastructure.Models
{
    public class CoverageType
    {
        public int CoverageTypeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PolicyCoverageType> PolicyCoverageTypes { get; set; }
    }
}
