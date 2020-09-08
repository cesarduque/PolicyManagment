using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Services.Implementation
{
    public class CoverageTypeService : ICoverageTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverageTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CoverageType Get(object code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CoverageType> Get(CoverageType entity)
        {
            return _unitOfWork.CoverageType.Get(entity);
        }
    }
}
