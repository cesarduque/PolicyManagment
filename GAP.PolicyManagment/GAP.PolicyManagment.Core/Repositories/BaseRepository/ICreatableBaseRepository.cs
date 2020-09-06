namespace GAP.PolicyManagment.Core.Repositories.BaseRepository
{
    public interface ICreatableRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);
    }
}
