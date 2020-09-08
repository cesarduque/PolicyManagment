namespace GAP.PolicyManagment.Core.Services.Interface.BaseService
{
    public interface IUpdatableBaseService<TEntity> where TEntity : class
    {
        void Update(TEntity entity);
    }   
}
