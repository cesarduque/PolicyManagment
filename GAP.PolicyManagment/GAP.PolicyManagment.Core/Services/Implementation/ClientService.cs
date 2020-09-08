using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Client Create(Client entity)
        {
            var clientSerach = new Client { Name = entity.Name };
            if (Get(clientSerach).Any())
            {
                throw new Exception("The Client is already created");
            }

            var c = entity.PolicyClients;
            entity.PolicyClients = null;

            _unitOfWork.Client.Create(entity);
            _unitOfWork.Confirm();

            var clientCreated = Get(entity).FirstOrDefault();

            var result = c.Select(ent =>
            {
                ent.Client = clientCreated;
                return ent;
            });

            _policyClientService.Create(result);

            return clientSerach;
        }

        public void Create(IEnumerable<Client> entity)
        {
            throw new NotImplementedException();
        }

        public Client Delete(Client entity)
        {
            _unitOfWork.Client.Delete(entity);
            _unitOfWork.Confirm();
            return entity;
        }

        public Client Get(object code)
        {
            return _unitOfWork.Client.Get(code);
        }

        public IEnumerable<Client> Get(Client entity)
        {
            return _unitOfWork.Client.Get(entity);
        }

        public void Update(Client entity)
        {
            _unitOfWork.Client.Update(entity);

            foreach (var item in entity.PolicyClients)
            {
                _policyClientService.Update(item);
            }

            _unitOfWork.Confirm();
        }
    }
}
