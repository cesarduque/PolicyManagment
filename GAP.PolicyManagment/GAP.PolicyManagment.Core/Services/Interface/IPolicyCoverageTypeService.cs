using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.PolicyManagment.Core.Services.Interface
{
    public interface IPolicyCoverageTypeService : ICreatableBaseService<PolicyCoverageType>,
        IDeletableBaseService<PolicyCoverageType>,
        IRecoverableBaseService<PolicyCoverageType>,
        IUpdatableBaseService<PolicyCoverageType>
    {
    }
}
