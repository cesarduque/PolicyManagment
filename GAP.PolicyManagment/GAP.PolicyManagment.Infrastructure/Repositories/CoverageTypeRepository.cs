using AutoMapper;
using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GAP.PolicyManagment.Infrastructure.Repositories
{
    public class CoverageTypeRepository : BaseRepository, ICoverageTypeRepository
    {
        readonly PolicyManagmentContext _context;

        public CoverageTypeRepository(PolicyManagmentContext context)
        {
            _context = context;
            MappingConfiguration();
        }

        internal override void MappingConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CoverageType, Models.CoverageType>()
                    .ReverseMap();                
                cfg.CreateMap<Client, Models.Client>()
                    .ReverseMap();
                cfg.CreateMap<PolicyCoverageType, Models.PolicyCoverageType>()
                    .ReverseMap();
                cfg.CreateMap<PolicyClient, Models.PolicyClient>()
                    .ReverseMap();
                cfg.CreateMap<RiskType, Models.RiskType>()
                    .ReverseMap();
                cfg.CreateMap<Policy, Models.Policy>()
                    .ReverseMap();
            });
            mapping = config.CreateMapper();
        }       

        public IEnumerable<CoverageType> Get(CoverageType entity)
        {
            List<Models.CoverageType> coverageTypes = null;

            if (entity == null)
            {
                coverageTypes = _context.CoverageTypes.ToList();
            }

            return mapping.Map<IEnumerable<CoverageType>>(coverageTypes);
        }        
    }
}
