using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories.BaseRepository;

namespace GAP.PolicyManagment.Core.Repositories
{
    public interface IPolicyRepository : ICreatableRepository<Policy>,
        IRecoverableRepository<Policy>,
        IDeletableRepository<Policy>,
        IUpdatableRepository<Policy>
    {        
    }
}
