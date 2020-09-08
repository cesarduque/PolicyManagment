using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.PolicyManagment.Core.Services.Interface
{
    public interface IPolicyClientService: ICreatableBaseService<PolicyClient>,
        IDeletableBaseService<PolicyClient>,
        IRecoverableBaseService<PolicyClient>,
        IUpdatableBaseService<PolicyClient>
    {
    }
}
