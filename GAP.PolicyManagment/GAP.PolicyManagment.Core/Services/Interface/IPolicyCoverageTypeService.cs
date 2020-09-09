using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface.BaseService;

namespace GAP.PolicyManagment.Core.Services.Interface
{
    public interface IPolicyCoverageTypeService : ICreatableBaseService<PolicyCoverageType>,
        IDeletableBaseService<PolicyCoverageType>,
        IRecoverableBaseService<PolicyCoverageType>,
        IUpdatableBaseService<PolicyCoverageType>
    {
    }
}
