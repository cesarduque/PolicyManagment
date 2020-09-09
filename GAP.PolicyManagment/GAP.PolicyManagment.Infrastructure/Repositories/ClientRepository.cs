using AutoMapper;
using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

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

        public IEnumerable<Client> Get(Client entity)
        {
            List<Models.Client> clients = null;

            if (entity == null)
            {
                clients = _context.Clients.ToList();
            }
            else
            {
                var query = (from client in _context.Clients.Include(c => c.PolicyClients) select client);
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
    }
}
