using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAP.PolicyManagment.Web.UI.Models
{
    public class Policy
    {
        public int PolicyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public int CoverageTime { get; set; }

        public double Price { get; set; }

        [Display(Name = "Risk")]
        public int RiskTypeId { get; set; }

        public RiskType RiskType { get; set; }

        public virtual ICollection<PolicyClient> PolicyClients { get; set; }

        public virtual ICollection<PolicyCoverageType> PolicyCoverageTypes { get; set; }

        public IEnumerable<SelectListItem> RiskTypeCollection { get; set; }        
    }
}