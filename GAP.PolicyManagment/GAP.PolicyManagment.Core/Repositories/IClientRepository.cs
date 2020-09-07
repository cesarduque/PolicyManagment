using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories.BaseRepository;

namespace GAP.PolicyManagment.Core.Repositories
{
    public interface IClientRepository : ICreatableRepository<Client>,
        IRecoverableRepository<Client>,
        IDeletableRepository<Client>,
        IUpdatableRepository<Client>
    {
    }
}
