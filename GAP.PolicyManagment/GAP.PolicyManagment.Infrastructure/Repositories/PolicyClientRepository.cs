using AutoMapper;
using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

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

        public void Create(PolicyClient entity)
        {
            var newPolicyClient = mapping.Map<Models.PolicyClient>(entity);
            newPolicyClient.Client = null;
            newPolicyClient.Policy = null;
            newPolicyClient.PolicyId = entity.PolicyId;
            newPolicyClient.ClientId = entity.ClientId;
            _context.PolicyClients.Add(mapping.Map<Models.PolicyClient>(newPolicyClient));            
        }       

        public void Delete(PolicyClient entity)
        {
            var policyClient = _context.PolicyClients.Find(entity.PolicyClientId);
            _context.PolicyClients.Remove(policyClient);            
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
                var query = (from policyCoveragee in _context.PolicyClients.Include(p => p.Policy) select policyCoveragee);
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
            var updatePolicyClient = mapping.Map<Models.PolicyClient>(entity.PolicyClientId);
            updatePolicyClient.Client = null;
            updatePolicyClient.Policy = null;
            updatePolicyClient.PolicyId = entity.PolicyId;
            updatePolicyClient.ClientId = entity.ClientId;
        }
    }
}

