using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Repositories.BaseRepository
{
    public interface ICreatableRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
    }
}