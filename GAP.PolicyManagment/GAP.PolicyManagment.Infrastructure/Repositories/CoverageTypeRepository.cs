using AutoMapper;
using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using System.Collections.Generic;

namespace GAP.PolicyManagment.Infrastructure.Repositories
{
    public class CoverageTypeRepository : BaseRepository, ICoverageTypeRepository
    {
        public CoverageTypeRepository()
        {
            MappingConfiguration();
        }

        internal override void MappingConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CoverageType, Models.CoverageType>()
                    .ReverseMap();
            });
            mapping = config.CreateMapper();
        }

        public CoverageType Get(object code)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CoverageType> Get(CoverageType entity)
        {
            throw new System.NotImplementedException();
        }        
    }
}
