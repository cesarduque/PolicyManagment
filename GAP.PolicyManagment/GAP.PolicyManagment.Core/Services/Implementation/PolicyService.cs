using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
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

        public Policy Create(Policy entity)
        {
            var policySerach = new Policy { Name = entity.Name };
            if (Get(policySerach).Any())
            {
                throw new Exception("The policy is already created");
            }

            var c = entity.PolicyCoverageTypes;
            entity.PolicyCoverageTypes = null;

            _unitOfWork.Policy.Create(entity);
            _unitOfWork.Confirm();

            var policyCreated = Get(entity).FirstOrDefault();

            var result = c.Select(ent =>
            {
                ent.Policy = policyCreated;
                return ent;
            });

            _policyCoverageTypeService.Create(result);

            return policyCreated;
        }

        public void Create(IEnumerable<Policy> entity)
        {
            throw new NotImplementedException();
        }

        public Policy Delete(Policy entity)
        {
            _unitOfWork.Policy.Delete(entity);
            _unitOfWork.Confirm();
            return entity;
        }

        public Policy Get(object code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Policy> Get(Policy entity)
        {
            return _unitOfWork.Policy.Get(entity);
        }

        public void Update(Policy entity)
        {
            _unitOfWork.Policy.Update(entity);            

            foreach (var item in entity.PolicyCoverageTypes)
            {
                _policyCoverageTypeService.Update(item);                
            }
           
            _unitOfWork.Confirm();
         
        }
    }
}
