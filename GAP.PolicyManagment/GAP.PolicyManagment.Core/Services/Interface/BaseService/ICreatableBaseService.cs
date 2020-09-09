using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Services.Interface.BaseService
{
    public interface ICreatableBaseService<TEntity> where TEntity : class
    {
        void Create(TEntity entity);        
    }    
}
