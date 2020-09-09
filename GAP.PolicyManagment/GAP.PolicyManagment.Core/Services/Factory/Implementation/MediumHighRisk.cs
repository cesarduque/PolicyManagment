namespace GAP.PolicyManagment.Core.Services
{
    public class MediumHighRisk : IRisk
    {
        public int CalcularMaximunCoverage()
        {
            return 100;
        }
    }
}
