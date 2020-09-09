using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.PolicyManagment.Core.Services
{
    public class LowRisk : IRisk
    {
        public int CalcularMaximunCoverage()
        {
            return 100;
        }
    }
}
