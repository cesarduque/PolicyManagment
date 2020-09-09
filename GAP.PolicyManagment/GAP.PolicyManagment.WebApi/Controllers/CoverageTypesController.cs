using GAP.PolicyManagment.Core.Services.Interface;
using System;
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

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_coverageTypeService.Get(null));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
