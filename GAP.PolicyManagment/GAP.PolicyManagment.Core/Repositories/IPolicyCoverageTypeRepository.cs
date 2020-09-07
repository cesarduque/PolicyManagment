using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.PolicyManagment.Core.Repositories
{
    public interface IPolicyCoverageTypeRepository : ICreatableRepository<PolicyCoverageType>,
        IRecoverableRepository<PolicyCoverageType>,
        IDeletableRepository<PolicyCoverageType>,
        IUpdatableRepository<PolicyCoverageType>
    {
    }
}
