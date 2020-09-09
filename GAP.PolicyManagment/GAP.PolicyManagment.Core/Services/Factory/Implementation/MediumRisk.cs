using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.PolicyManagment.Core.Services
{
    class MediumRisk : IRisk
    {
        public int CalcularMaximunCoverage()
        {
            return 100;
        }
    }
}
