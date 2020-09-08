using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Repositories.BaseRepository
{
    public interface ICreatableRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);

        void Create(IEnumerable<TEntity> entity);
    }
}
