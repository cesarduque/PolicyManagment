using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Services.Implementation
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client Create(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Create(IEnumerable<Client> entity)
        {
            throw new NotImplementedException();
        }

        public Client Delete(Client entidad)
        {
            throw new NotImplementedException();
        }

        public Client Get(object code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> Get(Client entity)
        {
            throw new NotImplementedException();
        }

        public Client Update(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
