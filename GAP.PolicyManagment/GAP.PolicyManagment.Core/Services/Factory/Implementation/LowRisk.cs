namespace GAP.PolicyManagment.Core.Services
{
    public class LowRisk : IRisk
    {
        public int CalcularMaximunCoverage()
        {
            return 100;
        }
    }
}
