using AutoMapper;
using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using System.Collections.Generic;

namespace GAP.PolicyManagment.Infrastructure.Repositories
{
    public class PolicyRepository : BaseRepository, IPolicyRepository
    {
        public PolicyRepository()
        {
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
            throw new System.NotImplementedException();
        }

        public Policy Delete(Policy entity)
        {
            throw new System.NotImplementedException();
        }

        public Policy Get(object code)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Policy> Get(Policy entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Policy entity)
        {
            throw new System.NotImplementedException();
        }        
    }
}
