using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GAP.PolicyManagment.WebApi.Controllers
{
    public class PolicyClientsController : ApiController
    {
        private readonly IPolicyClientService _policyClientService;

        public PolicyClientsController(IPolicyClientService policyClientService)
        {
            _policyClientService = policyClientService;
        }

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
