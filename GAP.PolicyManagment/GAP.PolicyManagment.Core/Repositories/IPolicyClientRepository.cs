using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories.BaseRepository;

namespace GAP.PolicyManagment.Core.Repositories
{
    public interface IPolicyClientRepository : ICreatableRepository<PolicyClient>,
        IRecoverableRepository<PolicyClient>,
        IDeletableRepository<PolicyClient>,
        IUpdatableRepository<PolicyClient>
    {
    }
}
