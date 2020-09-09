using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories.BaseRepository;

namespace GAP.PolicyManagment.Core.Repositories
{
    public interface IPolicyCoverageTypeRepository : ICreatableRepository<PolicyCoverageType>,
        IRecoverableRepository<PolicyCoverageType>,
        IDeletableRepository<PolicyCoverageType>,
        IUpdatableRepository<PolicyCoverageType>
    {
    }
}
