using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Services.Implementation
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPolicyClientService _policyClientService;

        public ClientService(IUnitOfWork unitOfWork, IPolicyClientService policyClientService)
        {
            _unitOfWork = unitOfWork;
            _policyClientService = policyClientService;
        }

        public IEnumerable<Client> Get(Client entity)
        {
            return _unitOfWork.Client.Get(entity);
        }        
    }
}
