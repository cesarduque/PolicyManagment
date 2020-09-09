using GAP.PolicyManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.PolicyManagment.Core.Services
{
    public interface IRiskFatory
    {
        IRisk CreateInstance(Policy entity);
    }
}
