namespace GAP.PolicyManagment.Core.Services.Interface.BaseService
{
    public interface IDeletableBaseService<TEntity> where TEntity : class
    {
        TEntity Delete(TEntity entidad);
    }    
}
