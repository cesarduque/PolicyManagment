using AutoMapper;
using GAP.PolicyManagment.Core.Entities;
using System.Collections.Generic;

namespace GAP.PolicyManagment.Infrastructure.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public ClientRepository()
        {
            MappingConfiguration();
        }

        internal override void MappingConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Client, Models.Client>()
                    .ReverseMap();
            });
            mapping = config.CreateMapper();
        }

        public Client Create(Client entity)
        {
            throw new System.NotImplementedException();
        }

        public Client Delete(Client entity)
        {
            throw new System.NotImplementedException();
        }

        public Client Get(object code)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Client> Get(Client entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Client entity)
        {
            throw new System.NotImplementedException();
        }        
    }
}
