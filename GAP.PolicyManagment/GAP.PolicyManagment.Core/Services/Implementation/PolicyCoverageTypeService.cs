using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GAP.PolicyManagment.Core.Services.Implementation
{
    public class PolicyCoverageTypeService : IPolicyCoverageTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PolicyCoverageTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(PolicyCoverageType entity)
        {
            _unitOfWork.PolicyCoverageType.Create(entity);
            _unitOfWork.Confirm();           
        }
      
        public void Delete(PolicyCoverageType entity)
        {
            _unitOfWork.PolicyCoverageType.Delete(entity);
            _unitOfWork.Confirm();
        }       

        public IEnumerable<PolicyCoverageType> Get(PolicyCoverageType entity)
        {            
            return _unitOfWork.PolicyCoverageType.Get(entity);
        }

        public void Update(PolicyCoverageType entity)
        {
            _unitOfWork.PolicyCoverageType.Update(entity);
            _unitOfWork.Confirm();
        }
    }
}
