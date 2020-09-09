using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GAP.PolicyManagment.Web.UI.Models
{
    public class Client
    {
        [Display(Name = "Client")]
        public int ClientId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PolicyClient> PolicyClients { get; set; }
    }
}