using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using EntitiesNeoris;
using DataNeoris.Interfaces;
using EntitiesNeoris.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaLeonardo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {

        private readonly ILogger<ReportesController> _logger;
        private readonly IDataReportes _data;

        public ReportesController(ILogger<ReportesController> logger, IDataReportes data)
        {
            _logger = logger;
            _data = data;
        }


        // GET api/<Clientes>/5
        [HttpGet("{fechaInicio}/{fechaFin}")]
        public IActionResult Get(DateTime fechaInicio, DateTime fechaFin)
        {
            EntitiesNeoris.Response.Respuesta objRespuesta = new EntitiesNeoris.Response.Respuesta();
            objRespuesta.Exito = 0;
            try
            {
                    objRespuesta.Data = _data.ConsultarReporteXFecha(fechaInicio,fechaFin);
                    if (objRespuesta.Data == null)
                    {
                        objRespuesta.Mensaje = "No se encontraton resultados";
                        return BadRequest(objRespuesta);
                    }
                    objRespuesta.Mensaje = "OK";
                    objRespuesta.Exito = 1;
                    return Ok(objRespuesta);
               

            }
            catch (Exception e)
            {
                _logger.LogError("Autenticación: " + e.Message, e);
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, e.Message);
            }

        }


    }
}
