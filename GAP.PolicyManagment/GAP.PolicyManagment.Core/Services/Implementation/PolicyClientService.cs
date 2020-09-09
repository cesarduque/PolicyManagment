using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Services.Implementation
{
    public class PolicyClientService : IPolicyClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PolicyClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(PolicyClient entity)
        {
            _unitOfWork.PolicyClient.Create(entity);
            _unitOfWork.Confirm();
        }        

        public void Delete(PolicyClient entity)
        {
            _unitOfWork.PolicyClient.Delete(entity);
            _unitOfWork.Confirm();            
        }       

        public IEnumerable<PolicyClient> Get(PolicyClient entity)
        {
            return _unitOfWork.PolicyClient.Get(entity);
        }

        public void Update(PolicyClient entity)
        {
            _unitOfWork.PolicyClient.Update(entity);
            _unitOfWork.Confirm();
        }
    }
}
