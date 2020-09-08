namespace GAP.PolicyManagment.Core.Entities
{
    public class PolicyCoverageType
    {
        public int PolicyCoverageTypeId { get; set; }
        public int PolicyId { get; set; }
        public Policy Policy { get; set; }
        public int CoverageTypeId { get; set; }
        public CoverageType CoverageType { get; set; }
        public int CoveragePercentage { get; set; }
    }
}
