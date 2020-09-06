using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface.BaseService;

namespace GAP.PolicyManagment.Core.Services.Interface
{
    public interface IClientService : ICreatableBaseService<Client>,
        IDeletableBaseService<Client>,
        IRecoverableBaseService<Client>,
        IUpdatableBaseService<Client>
    {        
    }
}
