using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Web.Http;

namespace GAP.PolicyManagment.WebApi.Controllers
{
    /// <summary>
    /// Implement operations realated to policies
    /// </summary>
    public class PoliciesController : ApiController
    {
        private readonly IPolicyService _policyService;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="policyService"></param>
        public PoliciesController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        /// <summary>
        /// Get Policies 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Create Policies 
        /// </summary>
        /// <param name="policy"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update Policies 
        /// </summary>
        /// <param name="policy"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete Policies 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
