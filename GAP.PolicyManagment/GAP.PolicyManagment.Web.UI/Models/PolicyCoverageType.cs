using System.ComponentModel.DataAnnotations;

namespace GAP.PolicyManagment.Web.UI.Models
{
    public class PolicyCoverageType
    {
        public int PolicyCoverageTypeId { get; set; }

        [Display(Name = "Policy")]
        public int PolicyId { get; set; }
        public Policy Policy { get; set; }

        [Display(Name = "Coverage Type")]
        public int CoverageTypeId { get; set; }
        public CoverageType CoverageType { get; set; }
        public int CoveragePercentage { get; set; }
    }
}