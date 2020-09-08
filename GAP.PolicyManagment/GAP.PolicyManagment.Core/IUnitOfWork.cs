using GAP.PolicyManagment.Core.Repositories;

namespace GAP.PolicyManagment.Core
{
    public interface IUnitOfWork
    {
        IClientRepository Client { get; }
        ICoverageTypeRepository CoverageType { get; }
        IPolicyRepository Policy { get; }
        IRiskTypeRepository RiskType { get; }
        IPolicyCoverageTypeRepository PolicyCoverageType { get; }
        IPolicyClientRepository PolicyClient { get; }

        int Confirm();
    }
}
