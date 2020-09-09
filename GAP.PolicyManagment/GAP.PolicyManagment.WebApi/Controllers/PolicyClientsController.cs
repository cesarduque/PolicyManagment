using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Web.Http;

namespace GAP.PolicyManagment.WebApi.Controllers
{
    /// <summary>
    /// Implement operations realated to policies clients
    /// </summary>
    public class PolicyClientsController : ApiController
    {
        private readonly IPolicyClientService _policyClientService;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="policyClientService"></param>
        public PolicyClientsController(IPolicyClientService policyClientService)
        {
            _policyClientService = policyClientService;
        }

        /// <summary>
        /// Get policies clients 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    return Ok(_policyClientService.Get(new PolicyClient { PolicyClientId = id }));
                }
                else
                {
                    return Ok(_policyClientService.Get(null));
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// Create policies clients 
        /// </summary>
        /// <param name="policyClient"></param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody]PolicyClient policyClient)
        {
            try
            {
                _policyClientService.Create(policyClient);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// Update policies clients 
        /// </summary>
        /// <param name="policyClient"></param>
        /// <returns></returns>
        public IHttpActionResult Put([FromBody] PolicyClient policyClient)
        {
            try
            {
                _policyClientService.Update(policyClient);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// Delete policies clients 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _policyClientService.Delete(new PolicyClient { PolicyClientId = id });
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
