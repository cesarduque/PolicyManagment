using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Web.Http;


namespace GAP.PolicyManagment.WebApi.Controllers
{
    public class RiskTypesController : ApiController
    {
        private readonly IRiskTypeService _riskTypeService;

        public RiskTypesController(IRiskTypeService riskTypeService)
        {
            _riskTypeService = riskTypeService;
        }
        
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
