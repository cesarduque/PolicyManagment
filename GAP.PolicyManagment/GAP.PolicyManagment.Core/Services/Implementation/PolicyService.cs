using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Services.Implementation
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository _policyRepository;

        public PolicyService(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        public Policy Create(Policy entity)
        {
            throw new NotImplementedException();
        }

        public void Create(IEnumerable<Policy> entity)
        {
            throw new NotImplementedException();
        }

        public Policy Delete(Policy entidad)
        {
            throw new NotImplementedException();
        }

        public Policy Get(object code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Policy> Get(Policy entity)
        {
            throw new NotImplementedException();
        }

        public Policy Update(Policy entity)
        {
            throw new NotImplementedException();
        }
    }
}
