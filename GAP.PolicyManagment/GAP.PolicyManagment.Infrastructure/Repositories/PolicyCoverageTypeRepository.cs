using AutoMapper;
using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public PolicyCoverageType Create(PolicyCoverageType entity)
        {
            var policyCoverageType = _context.PolicyCoverageTypes.Add(mapping.Map<Models.PolicyCoverageType>(entity));
            return mapping.Map<PolicyCoverageType>(policyCoverageType);
        }

        public void Create(IEnumerable<PolicyCoverageType> entities)
        {
            var result = mapping.Map<IEnumerable<Models.PolicyCoverageType>>(entities);

            var test = result.Select(ent =>
            {
                ent.CoverageTypeId = ent.CoverageType.CoverageTypeId;
                ent.CoverageType = null;
                ent.PolicyId = ent.Policy.PolicyId;
                ent.Policy = null;                
                return ent;
            });

            _context.PolicyCoverageTypes.AddRange(test);
        }

        public PolicyCoverageType Delete(PolicyCoverageType entity)
        {
            var policyCoverageType = _context.PolicyCoverageTypes.Find(entity.PolicyCoverageTypeId);
            _context.PolicyCoverageTypes.Remove(policyCoverageType);
            return mapping.Map<PolicyCoverageType>(policyCoverageType);
        }

        public PolicyCoverageType Get(object code)
        {
            var policyCoverageType = _context.PolicyCoverageTypes.Find(code);
            return mapping.Map<PolicyCoverageType>(policyCoverageType);
        }

        public IEnumerable<PolicyCoverageType> Get(PolicyCoverageType entity)
        {
            List<Models.PolicyCoverageType> policyCoverageType = null;

            if (entity == null)
            {
                policyCoverageType = _context.PolicyCoverageTypes.ToList();
            }
            else 
            {
                var query = (from policyCoveragee in _context.PolicyCoverageTypes select policyCoveragee);
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
        }
    }
}
