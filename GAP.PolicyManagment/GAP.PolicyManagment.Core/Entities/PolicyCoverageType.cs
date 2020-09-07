namespace GAP.PolicyManagment.Core.Entities
{
    public class PolicyCoverageType
    {
        public int PolicyCoverageTypeId { get; set; }
        public Policy Policy { get; set; }
        public CoverageType CoverageType { get; set; }
        public int CoveragePercentage { get; set; }
    }
}
