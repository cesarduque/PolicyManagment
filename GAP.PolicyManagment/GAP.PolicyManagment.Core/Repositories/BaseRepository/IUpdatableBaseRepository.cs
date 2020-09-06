namespace GAP.PolicyManagment.Core.Repositories.BaseRepository
{
    public interface IUpdatableRepository<TEntity> where TEntity : class
    {
        void Update(TEntity entity);
    }    
}
