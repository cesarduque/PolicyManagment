using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface.BaseService;

namespace GAP.PolicyManagment.Core.Services.Interface
{
    public interface IPolicyClientService: ICreatableBaseService<PolicyClient>,
        IDeletableBaseService<PolicyClient>,
        IRecoverableBaseService<PolicyClient>,
        IUpdatableBaseService<PolicyClient>
    {
    }
}
