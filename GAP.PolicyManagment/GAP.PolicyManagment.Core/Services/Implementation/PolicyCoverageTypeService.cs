using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.PolicyManagment.Core.Services.Implementation
{
    public class PolicyCoverageTypeService : IPolicyCoverageTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PolicyCoverageTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PolicyCoverageType Create(PolicyCoverageType entity)
        {
            throw new NotImplementedException();
        }

        public void Create(IEnumerable<PolicyCoverageType> entities)
        {
            _unitOfWork.PolicyCoverageType.Create(entities);
            _unitOfWork.Confirm();
        }

        public PolicyCoverageType Delete(PolicyCoverageType entidad)
        {
            throw new NotImplementedException();
        }

        public PolicyCoverageType Get(object code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PolicyCoverageType> Get(PolicyCoverageType entity)
        {
            throw new NotImplementedException();
        }

        public void Update(PolicyCoverageType entity)
        {
            _unitOfWork.PolicyCoverageType.Update(entity);
        }
    }
}
