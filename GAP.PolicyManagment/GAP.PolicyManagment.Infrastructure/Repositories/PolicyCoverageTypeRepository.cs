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
            });
            mapping = config.CreateMapper();
        }

        public PolicyCoverageType Create(PolicyCoverageType entity)
        {
            var policyCoverageType = _context.PolicyCoverageTypes.Add(mapping.Map<Models.PolicyCoverageType>(entity));
            return mapping.Map<PolicyCoverageType>(policyCoverageType);
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
            List<Models.PolicyCoverageType> policyCoverageTypes = null;

            if (entity == null)
            {
                policyCoverageTypes = _context.PolicyCoverageTypes.ToList();
            }

            return mapping.Map<IEnumerable<PolicyCoverageType>>(policyCoverageTypes);
        }

        public void Update(PolicyCoverageType entity)
        {
            var policyCoverageType = _context.PolicyCoverageTypes.Find(entity.PolicyCoverageTypeId);
            //policy.Name = entity.Name;
            //policy.Description = entity.Description;
            //policy.StartDate = entity.StartDate;
            //policy.CoverageTime = entity.CoverageTime;
            //policy.Price = entity.Price;
            //policy.RiskType = mapping.Map<Models.RiskType>(entity.RiskType);
        }
    }
}
