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
                cfg.CreateMap<Policy, Models.Policy>()
                    .ReverseMap();
                cfg.CreateMap<CoverageType, Models.CoverageType>()
                   .ReverseMap();
                cfg.CreateMap<RiskType, Models.RiskType>()
                    .ReverseMap();
                cfg.CreateMap<PolicyCoverageType, Models.PolicyCoverageType>()
                    .ReverseMap();
                cfg.CreateMap<PolicyClient, Models.PolicyClient>()
                    .ReverseMap();
            });
            mapping = config.CreateMapper();
        }

        public Client Create(Client entity)
        {
            var client = mapping.Map<Models.Client>(entity);
            client.PolicyClients = null;            
            client = _context.Clients.Add(mapping.Map<Models.Client>(client));
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
            else
            {
                var query = (from client in _context.Clients select client);
                if (entity.ClientId > 0)
                {
                    query = query.Where(c => c.ClientId == entity.ClientId);
                }
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    query = query.Where(c => c.Name == entity.Name);
                }
                clients = query.ToList();
            }

            return mapping.Map<IEnumerable<Client>>(clients);
        }

        public void Update(Client entity)
        {
            var policy = _context.Policies.Find(entity.ClientId);
            policy.Name = entity.Name;           
        }

        public void Create(IEnumerable<Client> entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
