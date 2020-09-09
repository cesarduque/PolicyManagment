using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Web.Http;


namespace GAP.PolicyManagment.WebApi.Controllers
{
    /// <summary>
    /// Implement operations realated to risk types
    /// </summary>
    public class RiskTypesController : ApiController
    {
        private readonly IRiskTypeService _riskTypeService;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="riskTypeService"></param>
        public RiskTypesController(IRiskTypeService riskTypeService)
        {
            _riskTypeService = riskTypeService;
        }

        /// <summary>
        /// Get policies risk types 
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            try
            {                
                return Ok (_riskTypeService.Get(null));                
            }           
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
