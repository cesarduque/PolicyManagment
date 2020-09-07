using AutoMapper;
using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GAP.PolicyManagment.Infrastructure.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        readonly PolicyManagmentContext _context;
        public ClientRepository(PolicyManagmentContext context)
        {
            _context = context;
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
            var client = _context.Clients.Add(mapping.Map<Models.Client>(entity));
            return mapping.Map<Client>(client);
        }

        public Client Delete(Client entity)
        {
            var client = _context.Clients.Find(entity.ClientId);
            _context.Clients.Remove(client);
            return mapping.Map<Client>(client);
        }

        public Client Get(object code)
        {
            var client = _context.Clients.Find(code);
            return mapping.Map<Client>(client);
        }    

        public IEnumerable<Client> Get(Client entity)
        {
            List<Models.Client> clients = null;

            if (entity == null)
            {
                clients = _context.Clients.ToList();
            }

            return mapping.Map<IEnumerable<Client>>(clients);
        }

        public void Update(Client entity)
        {
            var policy = _context.Policies.Find(entity.ClientId);
            policy.Name = entity.Name;           
        }        
    }
}
