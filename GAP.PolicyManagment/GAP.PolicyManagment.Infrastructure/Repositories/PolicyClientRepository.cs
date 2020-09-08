using AutoMapper;
using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GAP.PolicyManagment.Infrastructure.Repositories
{
    public class PolicyClientRepository : BaseRepository, IPolicyClientRepository
    {
        readonly PolicyManagmentContext _context;

        public PolicyClientRepository(PolicyManagmentContext context)
        {
            _context = context;
            MappingConfiguration();
        }

        internal override void MappingConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PolicyClient, Models.PolicyClient>()
                    .ReverseMap();
                cfg.CreateMap<Policy, Models.Policy>()
                    .ReverseMap();
                cfg.CreateMap<Client, Models.Client>()
                    .ReverseMap();
                cfg.CreateMap<PolicyCoverageType, Models.PolicyCoverageType>()
                    .ReverseMap();
                cfg.CreateMap<RiskType, Models.RiskType>()
                    .ReverseMap();
                cfg.CreateMap<CoverageType, Models.CoverageType>()
                    .ReverseMap();
            });
            mapping = config.CreateMapper();
        }

        public PolicyClient Create(PolicyClient entity)
        {
            var policyClient = _context.PolicyClients.Add(mapping.Map<Models.PolicyClient>(entity));
            return mapping.Map<PolicyClient>(policyClient);
        }

        public void Create(IEnumerable<PolicyClient> entities)
        {
            var result = mapping.Map<IEnumerable<Models.PolicyClient>>(entities);

            var test = result.Select(ent =>
            {
                ent.ClientId = ent.Client.ClientId;
                ent.Client = null;
                ent.PolicyId = ent.Policy.PolicyId;
                ent.Policy = null;
                return ent;
            });

            _context.PolicyClients.AddRange(test);
        }

        public PolicyClient Delete(PolicyClient entity)
        {
            var policyClient = _context.PolicyClients.Find(entity.ClientId);
            _context.PolicyClients.Remove(policyClient);
            return mapping.Map<PolicyClient>(policyClient);
        }

        public PolicyClient Get(object code)
        {
            var policyClient = _context.PolicyClients.Find(code);
            return mapping.Map<PolicyClient>(policyClient);
        }

        public IEnumerable<PolicyClient> Get(PolicyClient entity)
        {
            List<Models.PolicyClient> policyClients = null;

            if (entity == null)
            {
                policyClients = _context.PolicyClients.ToList();
            }
            else
            {
                var query = (from policyCoveragee in _context.PolicyClients select policyCoveragee);
                if (entity.PolicyClientId > 0)
                {
                    query = query.Where(c => c.PolicyClientId == entity.PolicyClientId);
                }
                if (entity.ClientId > 0)
                {
                    query = query.Where(c => c.ClientId == entity.ClientId);
                }
                if (entity.PolicyId > 0)
                {
                    query = query.Where(c => c.PolicyId == entity.PolicyId);
                }
                policyClients = query.ToList();
            }
            return mapping.Map<IEnumerable<PolicyClient>>(policyClients);
        }

        public void Update(PolicyClient entity)
        {
            var policyCoverageType = _context.PolicyClients.Find(entity.ClientId);           
        }
    }
}

