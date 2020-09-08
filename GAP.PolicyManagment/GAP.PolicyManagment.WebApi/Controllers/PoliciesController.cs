using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Linq;
using System.Web.Http;

namespace GAP.PolicyManagment.WebApi.Controllers
{
    public class PoliciesController : ApiController
    {
        private readonly IPolicyService _policyService;        

        public PoliciesController(IPolicyService policyService)
        {
            _policyService = policyService;
        }        

        public IHttpActionResult Get()
        {
            try
            {
                var policies = _policyService.Get(null);
                if (policies.Any())
                {
                    return Ok(policies);
                }

                return NotFound();
            }           
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public IHttpActionResult Post([FromBody]Policy policy)
        {
            try
            {
                return Ok(_policyService.Create(policy));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public IHttpActionResult Put([FromBody] Policy policy)
        {
            try
            {
                _policyService.Update(policy);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public IHttpActionResult Delete([FromBody]Policy policy)
        {
            try
            {
                return Ok(_policyService.Delete(policy));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
