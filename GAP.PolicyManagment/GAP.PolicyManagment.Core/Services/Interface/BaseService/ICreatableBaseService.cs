using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Services.Interface.BaseService
{
    public interface ICreatableBaseService<TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);

        void Create(IEnumerable<TEntity> entity);
    }    
}
