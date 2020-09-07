using AutoMapper;
using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GAP.PolicyManagment.Infrastructure.Repositories
{
    public class RiskTypeRepository : BaseRepository, IRiskTypeRepository
    {
        readonly PolicyManagmentContext _context;

        public RiskTypeRepository(PolicyManagmentContext context)
        {
            _context = context;
            MappingConfiguration();
        }

        internal override void MappingConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RiskType, Models.RiskType>()
                    .ReverseMap();
            });
            mapping = config.CreateMapper();
        }

        public RiskType Get(object code)
        {
            var riskType = _context.RiskTypes.Find(code);
            return mapping.Map<RiskType>(riskType);
        }

        public IEnumerable<RiskType> Get(RiskType entity)
        {
            List<Models.RiskType> riskTypes = null;

            if (entity == null)
            {
                riskTypes = _context.RiskTypes.ToList();
            }

            return mapping.Map<IEnumerable<RiskType>>(riskTypes);
        }        
    }   
}
