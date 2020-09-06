using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Repositories.BaseRepository
{
    public interface IRecoverableRepository<TEntity> where TEntity : class
    {
        TEntity Get(object code);

        IEnumerable<TEntity> Get(TEntity entity);
    }
}
