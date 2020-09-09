using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GAP.PolicyManagment.Core.Services.Implementation
{
    public class PolicyService : IPolicyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPolicyCoverageTypeService _policyCoverageTypeService;

        public PolicyService(IUnitOfWork unitOfWork, IPolicyCoverageTypeService policyCoverageTypeService)
        {
            _unitOfWork = unitOfWork;
            _policyCoverageTypeService = policyCoverageTypeService;
        }

        public PolicyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }

        public void Create(Policy entity)
        {
            var policySerach = new Policy { Name = entity.Name };
            if (Get(policySerach).Any())
            {
                throw new Exception("The policy is already created");
            }          

            _unitOfWork.Policy.Create(entity);
            _unitOfWork.Confirm();
        }       

        public void Delete(Policy entity)
        {
            _unitOfWork.Policy.Delete(entity);
            _unitOfWork.Confirm();            
        }       

        public IEnumerable<Policy> Get(Policy entity)
        {
            return _unitOfWork.Policy.Get(entity);
        }

        public void Update(Policy entity)
        {
            _unitOfWork.Policy.Update(entity);           
            _unitOfWork.Confirm();         
        }
    }
}
