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
    public class CuentasController : ControllerBase
    {

        private readonly ILogger<CuentasController> _logger;
        private readonly IDataCuenta _data;

        public CuentasController(ILogger<CuentasController> logger, IDataCuenta data)
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
                objRespuesta.Data = _data.ConsultarCuentas();
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
        [HttpGet("{Identificacion}")]
        public IActionResult Get(int Identificacion)
        {
            EntitiesNeoris.Response.Respuesta objRespuesta = new EntitiesNeoris.Response.Respuesta();
            objRespuesta.Exito = 0;
            try
            {
                objRespuesta.Data = _data.ConsultarCuentasXIdentificacion(Identificacion);
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
        [Route("SaveCuenta")]
        public IActionResult SaveCuenta([FromBody] EntitiesNeoris.EntityCuentaSP data)
        {
            EntitiesNeoris.Response.Respuesta objRespuesta = new EntitiesNeoris.Response.Respuesta();
            objRespuesta.Exito = 0;
            try
            {
                IEnumerable<RespuestaGenerica> info = _data.guardarCuenta(data);
                objRespuesta.Data = info.FirstOrDefault().Valor;

                if (objRespuesta.Data == null)
                {
                    objRespuesta.Mensaje = "Ocurrio un error al registrar la cuenta";
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
        public IActionResult Put([FromBody] EntitiesNeoris.EntityCuentaSP data)
        {
            EntitiesNeoris.Response.Respuesta objRespuesta = new EntitiesNeoris.Response.Respuesta();
            objRespuesta.Exito = 0;
            try
            {
                if (data.Cuenta_ID != null)
                {
                    IEnumerable<RespuestaGenerica> info = _data.actualizarCuenta(data);
                    objRespuesta.Data = info.FirstOrDefault().Valor;

                    if (objRespuesta.Data == null)
                    {
                        objRespuesta.Mensaje = "Ocurrio un error al actualizar la cuenta";
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

                    objRespuesta.Mensaje = "No se envio el campo 'Cuenta_ID'";
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

                IEnumerable<RespuestaGenerica> info = _data.EliminarCuenta(id);
                objRespuesta.Data = info.FirstOrDefault().Valor;

                if (objRespuesta.Data == null)
                {
                    objRespuesta.Mensaje = "Ocurrio un error al eliminar la cuenta";
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
