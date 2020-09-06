using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface.BaseService;

namespace GAP.PolicyManagment.Core.Services.Interface
{
    public interface IPolicyService : ICreatableBaseService<Policy>,
        IDeletableBaseService<Policy>,
        IRecoverableBaseService<Policy>,
        IUpdatableBaseService<Policy>
    {
       
    }
}
