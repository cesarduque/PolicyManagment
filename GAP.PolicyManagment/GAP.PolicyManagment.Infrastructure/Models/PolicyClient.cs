namespace GAP.PolicyManagment.Infrastructure.Models
{
    public class PolicyClient
    {
        public int PolicyClientId { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int PolicyId { get; set; }

        public Policy Policy { get; set; }

    }
}
