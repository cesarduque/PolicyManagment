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
        private readonly IRiskFatory _riskFactory;      

        public PolicyCoverageTypeService(IUnitOfWork unitOfWork, IRiskFatory riskFactory)
        {
            _unitOfWork = unitOfWork;            
            _riskFactory = riskFactory;
        }

        public void Create(PolicyCoverageType entity)
        {
            if (ValidateCoveragePercentage(entity))
            {
                _unitOfWork.PolicyCoverageType.Create(entity);
                _unitOfWork.Confirm();
            }
            else
            {
                throw new Exception("The coverage for this risk is more than 50%");
            }
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
            if (ValidateCoveragePercentage(entity))
            {
                _unitOfWork.PolicyCoverageType.Update(entity);
                _unitOfWork.Confirm();
            }
            else
            {
                throw new Exception("The coverage for this risk is more than 50%");
            }
        }

        private bool ValidateCoveragePercentage(PolicyCoverageType entity)
        {
            var policy = _unitOfWork.Policy.Get(new Policy { PolicyId = entity.PolicyId }).FirstOrDefault();          

            return entity.CoveragePercentage <= _riskFactory.CreateInstance(policy).CalcularMaximunCoverage();            
        }
    }
}
