using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.PolicyManagment.Core.Services.Implementation
{
    public class RiskTypeService : IRiskTypeService
    {
        private readonly IRiskTypeRepository _riskTypeRepository;

        public RiskTypeService(IRiskTypeRepository riskTypeRepository)
        {
            _riskTypeRepository = riskTypeRepository;
        }
        public RiskType Get(object code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RiskType> Get(RiskType entity)
        {
            throw new NotImplementedException();
        }
    }
}
