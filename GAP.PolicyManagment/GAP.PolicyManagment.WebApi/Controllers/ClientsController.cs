using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Web.Http;

namespace GAP.PolicyManagment.WebApi.Controllers
{
    /// <summary>
    /// Implement operations realated to clients
    /// </summary>
    public class ClientsController : ApiController
    {
        private readonly IClientService _clientService;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="clientService"></param>
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Get cllient by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    return Ok(_clientService.Get(new Client { ClientId = id }));
                }
                else {
                    return Ok(_clientService.Get(null));
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
