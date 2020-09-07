using AutoMapper;
using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

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
            });
            mapping = config.CreateMapper();
        }

        public Policy Create(Policy entity)
        {
            var policy = _context.Policies.Add(mapping.Map<Models.Policy>(entity));
            return mapping.Map<Policy>(policy);
        }

        public Policy Delete(Policy entity)
        {
            var policy = _context.Policies.Find(entity.PolicyId);
            _context.Policies.Remove(policy);
            return mapping.Map<Policy>(policy);
        }

        public Policy Get(object code)
        {
            var policy = _context.Policies.Find(code);
            return mapping.Map<Policy>(policy);
        }

        public IEnumerable<Policy> Get(Policy entity)
        {
            List<Models.Policy> policies = null;

            if (entity == null)
            {
                policies = _context.Policies.ToList();
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
            policy.RiskType = mapping.Map<Models.RiskType>(entity.RiskType);
        }        
    }
}
