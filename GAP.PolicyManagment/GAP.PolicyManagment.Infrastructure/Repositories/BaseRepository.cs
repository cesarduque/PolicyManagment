using AutoMapper;

namespace GAP.PolicyManagment.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        protected IMapper mapping;

        /// <summary>
        /// Configura mapeo entre entidades
        /// </summary>
        internal abstract void MappingConfiguration();
    }
}
