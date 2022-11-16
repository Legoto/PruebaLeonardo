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
    public class MovimientosController : ControllerBase
    {

        private readonly ILogger<MovimientosController> _logger;
        private readonly IDataMovimiento _data;

        public MovimientosController(ILogger<MovimientosController> logger, IDataMovimiento data)
        {
            _logger = logger;
            _data = data;
        }

        // GET: api/<Clientes>
        [HttpGet]
        public IActionResult Get()
        {
            EntitiesNeoris.Response.Respuesta objRespuesta = new EntitiesNeoris.Response.Respuesta();
            objRespuesta.Exito = 0;
            try
            {
                objRespuesta.Data = _data.ConsultarMovimientos();
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


        // GET api/<Clientes>/5
        [HttpGet("{numerCuenta}")]
        public IActionResult Get(string numerCuenta)
        {
            EntitiesNeoris.Response.Respuesta objRespuesta = new EntitiesNeoris.Response.Respuesta();
            objRespuesta.Exito = 0;
            try
            {
                objRespuesta.Data = _data.ConsultarCuentasXNumerCuenta(numerCuenta);
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



        [HttpPost]
        [Route("SaveMovimiento")]
        public IActionResult SaveCuenta([FromBody] EntitiesNeoris.EntityMovimientoSP data)
        {
            EntitiesNeoris.Response.Respuesta objRespuesta = new EntitiesNeoris.Response.Respuesta();
            objRespuesta.Exito = 0;
            try
            {
                IEnumerable<RespuestaGenerica> info = _data.guardarMovimiento(data);
                objRespuesta.Data = info.FirstOrDefault().Valor;

                if (objRespuesta.Data == null)
                {
                    objRespuesta.Mensaje = "Ocurrio un error al registrar el movimiento";
                    return BadRequest(objRespuesta);
                }
                if (info != null && !string.IsNullOrEmpty(info.FirstOrDefault().Respuesta)) {
                    objRespuesta.Mensaje = info.FirstOrDefault().Respuesta;
                    objRespuesta.Exito = info.FirstOrDefault().Id;
                }
                return Ok(objRespuesta);

            }
            catch (Exception e)
            {
                _logger.LogError("Autenticación: " + e.Message, e);
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, e.Message);
            }

        }

        // PUT api/<Clientes>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] EntitiesNeoris.EntityMovimientoSP data)
        {
            EntitiesNeoris.Response.Respuesta objRespuesta = new EntitiesNeoris.Response.Respuesta();
            objRespuesta.Exito = 0;
            try
            {
                if (data.MOVIMIENTO_ID != null)
                {
                    IEnumerable<RespuestaGenerica> info = _data.actualizarMovimiento(data);
                    objRespuesta.Data = info.FirstOrDefault().Valor;

                    if (objRespuesta.Data == null)
                    {
                        objRespuesta.Mensaje = "Ocurrio un error al actualizar el movimiento";
                        return BadRequest(objRespuesta);
                    }
                    if (info != null && !string.IsNullOrEmpty(info.FirstOrDefault().Respuesta))
                    {
                        objRespuesta.Mensaje = info.FirstOrDefault().Respuesta;
                        objRespuesta.Exito = info.FirstOrDefault().Id;
                    }
                    return Ok(objRespuesta);
                }
                else
                {

                    objRespuesta.Mensaje = "No se envio el campo 'MOVIMIENTO_ID'";
                    return BadRequest(objRespuesta);
                }

            }
            catch (Exception e)
            {
                _logger.LogError("Autenticación: " + e.Message, e);
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, e.Message);
            }

        }

        // DELETE api/<Clientes>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EntitiesNeoris.Response.Respuesta objRespuesta = new EntitiesNeoris.Response.Respuesta();
            objRespuesta.Exito = 0;
            try
            {

                IEnumerable<RespuestaGenerica> info = _data.EliminarMovimiento(id);
                objRespuesta.Data = info.FirstOrDefault().Valor;

                if (objRespuesta.Data == null)
                {
                    objRespuesta.Mensaje = "Ocurrio un error al eliminar el movimiento";
                    return BadRequest(objRespuesta);
                }
                if (info != null && !string.IsNullOrEmpty(info.FirstOrDefault().Respuesta))
                {
                    objRespuesta.Mensaje = info.FirstOrDefault().Respuesta;
                    objRespuesta.Exito = info.FirstOrDefault().Id;
                }
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
