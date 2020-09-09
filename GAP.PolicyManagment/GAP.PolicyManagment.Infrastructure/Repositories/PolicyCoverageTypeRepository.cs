using AutoMapper;
using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GAP.PolicyManagment.Infrastructure.Repositories
{
    public class PolicyCoverageTypeRepository : BaseRepository, IPolicyCoverageTypeRepository
    {
        readonly PolicyManagmentContext _context;

        public PolicyCoverageTypeRepository(PolicyManagmentContext context)
        {
            _context = context;
            MappingConfiguration();
        }

        internal override void MappingConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PolicyCoverageType, Models.PolicyCoverageType>()
                    .ReverseMap();
                cfg.CreateMap<Policy, Models.Policy>()
                    .ReverseMap();
                cfg.CreateMap<CoverageType, Models.CoverageType>()
                    .ReverseMap();
            });
            mapping = config.CreateMapper();
        }

        public void Create(PolicyCoverageType entity)
        {
            var newPolicyCoverageType = new PolicyCoverageType { 
                CoverageType = null,
                Policy = null,
                CoveragePercentage = entity.CoveragePercentage,
                PolicyId = entity.PolicyId,
                CoverageTypeId = entity.CoverageTypeId
            };
            _context.PolicyCoverageTypes.Add(mapping.Map<Models.PolicyCoverageType>(newPolicyCoverageType));            
        }        

        public void Delete(PolicyCoverageType entity)
        {
            var policyCoverageType = _context.PolicyCoverageTypes.Find(entity.PolicyCoverageTypeId);
            _context.PolicyCoverageTypes.Remove(policyCoverageType);            
        }        

        public IEnumerable<PolicyCoverageType> Get(PolicyCoverageType entity)
        {
            List<Models.PolicyCoverageType> policyCoverageType = null;

            if (entity == null)
            {
                policyCoverageType = _context.PolicyCoverageTypes.Include(p => p.CoverageType).ToList();
            }
            else 
            {
                var query = (from policyCoveragee in _context.PolicyCoverageTypes.Include(p => p.CoverageType) select policyCoveragee);
                if (entity.PolicyCoverageTypeId > 0)
                {
                    query = query.Where(c => c.PolicyCoverageTypeId == entity.PolicyCoverageTypeId);
                }
                if (entity.PolicyId > 0)
                {
                    query = query.Where(c => c.PolicyId == entity.PolicyId);
                }
                policyCoverageType = query.ToList();
            }
            return mapping.Map<IEnumerable<PolicyCoverageType>>(policyCoverageType);
        }

        public void Update(PolicyCoverageType entity)
        {
            var policyCoverageType = _context.PolicyCoverageTypes.Find(entity.PolicyCoverageTypeId);
            policyCoverageType.CoveragePercentage = entity.CoveragePercentage;
            policyCoverageType.CoverageTypeId = entity.CoverageTypeId;
        }
    }
}
