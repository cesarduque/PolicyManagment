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
    public class RiskTypesController : ApiController
    {
        private readonly IRiskTypeService _riskTypeService;

        public RiskTypesController(IRiskTypeService riskTypeService)
        {
            _riskTypeService = riskTypeService;
        }

        [HttpGet]
        public ActionResult<RiskType> Get([FromQuery] RiskType riskTypeService)
        {
            try
            {
                var empresas = _empresaServicio.Recuperar(empresa);
                if (empresas.Any())
                {
                    return new RespuestaServicio<IEnumerable<Empresa>>(HttpStatusCode.OK, empresas, string.Empty);
                }

                return new RespuestaServicio<Empresa>(HttpStatusCode.NoContent, null, Mensajes.NO_HAY_REGISTROS);
            }
            catch (NegocioExcepcion e)
            {
                return new RespuestaServicio<Empresa>(HttpStatusCode.BadRequest, null, e.Message);
            }
            catch (Exception e)
            {
                return new RespuestaServicio<Empresa>(HttpStatusCode.InternalServerError, null, e.Message);
            }
        }
    }
}
