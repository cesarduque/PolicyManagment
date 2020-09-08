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
    public class ClientsController : ApiController
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IHttpActionResult Get()
        {
            try
            {
                var clients = _clientService.Get(null);
                if (clients.Any())
                {
                    return Ok(clients);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public IHttpActionResult Post([FromBody]Client client)
        {
            try
            {
                return Ok(_clientService.Create(client));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        
        public IHttpActionResult Put([FromBody]Client client)
        {
            try
            {
                _clientService.Update(client);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        
        public IHttpActionResult Delete([FromBody]Client client)
        {
            try
            {
                return Ok(_clientService.Delete(client));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
