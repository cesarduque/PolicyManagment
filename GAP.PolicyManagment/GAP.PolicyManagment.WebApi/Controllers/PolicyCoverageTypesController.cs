using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Web.Http;

namespace GAP.PolicyManagment.WebApi.Controllers
{
    public class PolicyCoverageTypesController : ApiController
    {
        private readonly IPolicyCoverageTypeService _policyCoverageTypeService;

        public PolicyCoverageTypesController(IPolicyCoverageTypeService policyCoverageTypeService)
        {
            _policyCoverageTypeService = policyCoverageTypeService;
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    return Ok(_policyCoverageTypeService.Get(new PolicyCoverageType { PolicyCoverageTypeId = id }));
                }
                else
                {
                    return Ok(_policyCoverageTypeService.Get(null));
                }                
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public IHttpActionResult Post([FromBody]PolicyCoverageType policyCoverageType)
        {
            try
            {
                _policyCoverageTypeService.Create(policyCoverageType);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public IHttpActionResult Put([FromBody] PolicyCoverageType policyCoverageType)
        {
            try
            {
                _policyCoverageTypeService.Update(policyCoverageType);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                _policyCoverageTypeService.Delete(new PolicyCoverageType { PolicyCoverageTypeId = id });
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
