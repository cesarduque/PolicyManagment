using GAP.PolicyManagment.Core.Entities;

namespace GAP.PolicyManagment.Core.Services
{
    public class RiskFactory : IRiskFatory
    {
        public IRisk CreateInstance(Policy policy) 
        {
            IRisk result;

            switch (policy.RiskType.Name)
            {
                case "Bajo":
                    result = new HighRisk();
                    break;
                case "Medio":
                    result = new MediumRisk();
                    break;
                case "Medio-Alto":
                    result = new MediumHighRisk();
                    break;
                case "Alto":
                    result = new HighRisk();
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }
    }
}
