using GAP.PolicyManagment.Core.Entities;
using GAP.PolicyManagment.Core.Services.Interface;
using System;
using System.Web.Http;

namespace GAP.PolicyManagment.WebApi.Controllers
{
    public class ClientsController : ApiController
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

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
