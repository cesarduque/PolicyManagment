namespace GAP.PolicyManagment.Core.Services.Interface.BaseService
{
    public interface IDeletableBaseService<TEntity> where TEntity : class
    {
        void Delete(TEntity entidad);
    }    
}
