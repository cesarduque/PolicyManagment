namespace GAP.PolicyManagment.Core.Services.Interface.BaseService
{
    public interface IUpdatableBaseService<TEntity> where TEntity : class
    {
        TEntity Update(TEntity entity);
    }   
}
