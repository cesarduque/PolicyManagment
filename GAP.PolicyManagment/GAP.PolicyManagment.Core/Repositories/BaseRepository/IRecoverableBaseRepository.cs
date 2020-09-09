using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Repositories.BaseRepository
{
    public interface IRecoverableRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(TEntity entity);
    }
}
