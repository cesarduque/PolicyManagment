using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.PolicyManagment.Core.Services.Implementation
{
    public class PolicyClientService : IPolicyClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PolicyClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PolicyClient Create(PolicyClient entity)
        {
            throw new NotImplementedException();
        }

        public void Create(IEnumerable<PolicyClient> entities)
        {
            _unitOfWork.PolicyClient.Create(entities);
            _unitOfWork.Confirm();
        }

        public PolicyClient Delete(PolicyClient entidad)
        {
            throw new NotImplementedException();
        }

        public PolicyClient Get(object code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PolicyClient> Get(PolicyClient entity)
        {
            throw new NotImplementedException();
        }

        public void Update(PolicyClient entity)
        {
            _unitOfWork.PolicyClient.Update(entity);
        }
    }
}
