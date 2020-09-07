using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Repositories;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Services.Implementation
{
    public class CoverageTypeService : ICoverageTypeService
    {
        private readonly ICoverageTypeRepository _coverageTypeRepository;

        public CoverageTypeService(ICoverageTypeRepository coverageTypeRepository)
        {
            _coverageTypeRepository = coverageTypeRepository;
        }

        public CoverageType Get(object code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CoverageType> Get(CoverageType entity)
        {
            throw new NotImplementedException();
        }
    }
}
