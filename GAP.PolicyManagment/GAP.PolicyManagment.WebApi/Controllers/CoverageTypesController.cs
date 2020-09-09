using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Web.Http;

namespace GAP.PolicyManagment.WebApi.Controllers
{
    /// <summary>
    /// Implement operations realated to Coverage Types
    /// </summary>
    public class CoverageTypesController : ApiController
    {
        private readonly ICoverageTypeService _coverageTypeService;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="coverageTypeService"></param>
        public CoverageTypesController(ICoverageTypeService coverageTypeService)
        {
            _coverageTypeService = coverageTypeService;
        }

        /// <summary>
        /// Get coverage type
        /// </summary>
        /// <returns></returns>
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
