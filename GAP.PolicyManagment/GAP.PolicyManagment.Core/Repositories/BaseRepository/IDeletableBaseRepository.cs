namespace GAP.PolicyManagment.Core.Repositories.BaseRepository
{
    public interface IDeletableRepository<TEntity> where TEntity : class
    {
        TEntity Delete(TEntity entity);
    }
}
