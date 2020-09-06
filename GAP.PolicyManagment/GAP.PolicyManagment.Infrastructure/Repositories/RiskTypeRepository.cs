using AutoMapper;
using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using System.Collections.Generic;

namespace GAP.PolicyManagment.Infrastructure.Repositories
{
    public class RiskTypeRepository : BaseRepository, IRiskTypeRepository
    {
        public RiskTypeRepository()
        {
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
            throw new System.NotImplementedException();
        }

        public IEnumerable<RiskType> Get(RiskType entity)
        {
            throw new System.NotImplementedException();
        }

        
    }   
}
