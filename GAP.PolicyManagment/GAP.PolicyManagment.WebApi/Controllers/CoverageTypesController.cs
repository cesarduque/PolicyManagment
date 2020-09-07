using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GAP.PolicyManagment.WebApi.Controllers
{
    public class CoverageTypesController : ApiController
    {
        private readonly ICoverageTypeService _coverageTypeService;

        public CoverageTypesController(ICoverageTypeService coverageTypeService)
        {
            _coverageTypeService = coverageTypeService;
        }
    }
}
