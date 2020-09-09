using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GAP.PolicyManagment.Web.UI.Models
{
    public class PolicyClient
    {
        public int PolicyClientId { get; set; }

        [Display(Name = "Client")]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        [Display(Name = "Policy")]
        public int PolicyId { get; set; }

        public Policy Policy { get; set; }

        public IEnumerable<SelectListItem> PolicyCollection { get; set; }
    }
}