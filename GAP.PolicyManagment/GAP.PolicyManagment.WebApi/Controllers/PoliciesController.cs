using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
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

        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    return Ok(_policyService.Get(new Policy { PolicyId = id }));
                }
                else
                {
                    return Ok(_policyService.Get(null));
                }                
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
                _policyService.Create(policy);
                return Ok();
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

        public IHttpActionResult Delete(int id)
        {
            try
            {
                _policyService.Delete(new Policy { PolicyId = id });
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
