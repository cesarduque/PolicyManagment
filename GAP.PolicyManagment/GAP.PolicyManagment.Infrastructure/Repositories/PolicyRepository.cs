using AutoMapper;
using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace GAP.PolicyManagment.Infrastructure.Repositories
{
    public class PolicyRepository : BaseRepository, IPolicyRepository
    {
        readonly PolicyManagmentContext _context;

        public PolicyRepository(PolicyManagmentContext context)
        {
            _context = context;
            MappingConfiguration();
        }

        internal override void MappingConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Policy, Models.Policy>()
                    .ReverseMap();
                cfg.CreateMap<RiskType, Models.RiskType>()
                    .ReverseMap();
                cfg.CreateMap<CoverageType, Models.CoverageType>()
                    .ReverseMap();
                cfg.CreateMap<Client, Models.Client>()
                    .ReverseMap();
                cfg.CreateMap<PolicyCoverageType, Models.PolicyCoverageType>()
                    .ReverseMap();
                cfg.CreateMap<PolicyClient, Models.PolicyClient>()
                    .ReverseMap();
            });
            mapping = config.CreateMapper();
        }

        public void Create(Policy entity)
        {
            var newPolicy = mapping.Map<Models.Policy>(entity);
            newPolicy.RiskType = null;
            newPolicy.PolicyClients = null;
            newPolicy.RiskTypeId = entity.RiskTypeId;
            newPolicy = _context.Policies.Add(mapping.Map<Models.Policy>(newPolicy));            
        }

        public void Delete(Policy entity)
        {
            var policy = _context.Policies.Find(entity.PolicyId);
            _context.Policies.Remove(policy);            
        }       

        public IEnumerable<Policy> Get(Policy entity)
        {
            List<Models.Policy> policies = null;

            if (entity == null)
            {
                policies = _context.Policies.ToList();
            }
            else
            {
                var query = (from policy in _context.Policies.Include(p => p.PolicyCoverageTypes) select policy);
                if (entity.PolicyId > 0)
                {
                    query = query.Where(c => c.PolicyId == entity.PolicyId);
                }
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    query = query.Where(c => c.Name == entity.Name);
                }
                policies = query.ToList();
            }
            return mapping.Map<IEnumerable<Policy>>(policies);
        }

        public void Update(Policy entity)
        {
            var policy = _context.Policies.Find(entity.PolicyId);
            policy.Name = entity.Name;
            policy.Description = entity.Description;
            policy.StartDate = entity.StartDate;
            policy.CoverageTime = entity.CoverageTime;
            policy.Price = entity.Price;
            policy.RiskTypeId = entity.RiskTypeId;
        }        
    }
}
