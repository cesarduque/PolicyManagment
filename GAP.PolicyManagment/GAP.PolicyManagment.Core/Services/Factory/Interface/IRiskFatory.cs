using GAP.PolicyManagment.Core.Entities;

namespace GAP.PolicyManagment.Core.Services
{
    public interface IRiskFatory
    {
        IRisk CreateInstance(Policy entity);
    }
}
