using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Services.Implementation
{
    public class RiskTypeService : IRiskTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RiskTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }       

        public IEnumerable<RiskType> Get(RiskType entity)
        {
            return _unitOfWork.RiskType.Get(entity);
        }
    }
}
