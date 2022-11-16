using DataNeoris.Interfaces;
using EntitiesNeoris;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.IO;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EntitiesNeoris.Response;

namespace DataNeoris
{

    public class DataCliente : IDataCliente
    {
        private readonly AppDbContext context;
        public DataCliente(AppDbContext context)
        {
            this.context = context;
        }
        private object isNull(string valor)
        {
            if (valor == "" || valor == null)
                return DBNull.Value;
            else
                return valor;
        }
        public IEnumerable<EntityClienteResponse> ConsultarClientes()
        {

            SqlParameter operacion = new SqlParameter("OPERACION", 3);
            return context.EntityClienteResponse.FromSqlRaw("EXEC[QRY].[CRUD_TblCLiente] @OPERACION",
              operacion).ToList();
        }

        public IEnumerable<EntityClienteResponse> ConsultarClienteXIdentificacion(int identificacion)
        {
            SqlParameter Persona_ID = new SqlParameter("PERSONA_ID", DBNull.Value);
            SqlParameter Nombre = new SqlParameter("NOMBRE", DBNull.Value);
            SqlParameter Genero = new SqlParameter("GENERO", DBNull.Value);
            SqlParameter Edad = new SqlParameter("EDAD", DBNull.Value);
            SqlParameter Tipo_identificacion = new SqlParameter("TIPO_IDENTIFICACION", DBNull.Value);
            SqlParameter Identificacion = new SqlParameter("IDENTIFICACION", int.Parse(identificacion.ToString()));
            SqlParameter Direccion = new SqlParameter("DIRECCION", DBNull.Value);
            SqlParameter Telefono = new SqlParameter("TELEFONO", DBNull.Value);
            SqlParameter Estado = new SqlParameter("ESTADO", DBNull.Value);
            SqlParameter contrasenna = new SqlParameter("CONTRASENNA", DBNull.Value);
            SqlParameter operacion = new SqlParameter("OPERACION", int.Parse("4"));

            return context.EntityClienteResponse.FromSqlRaw("EXEC[QRY].[CRUD_TblCLiente] " +
                "@PERSONA_ID,@NOMBRE,@GENERO,@EDAD,@TIPO_IDENTIFICACION,@IDENTIFICACION,@DIRECCION,@TELEFONO,@ESTADO,@CONTRASENNA,@OPERACION",
                Persona_ID, Nombre, Genero, Edad, Tipo_identificacion, Identificacion, Direccion, Telefono, Estado, contrasenna, operacion).ToList();
            
        }

        public IEnumerable<RespuestaGenerica> guardarCliente(EntityClienteSP datos)
        {
            try
            {
                SqlParameter Persona_ID = new SqlParameter("PERSONA_ID", DBNull.Value);
                SqlParameter Nombre = new SqlParameter("NOMBRE", isNull(datos.Nombre));
                SqlParameter Genero = new SqlParameter("GENERO", isNull(datos.Genero));
                SqlParameter Edad = new SqlParameter("EDAD", int.Parse(datos.Edad.ToString()));
                SqlParameter Tipo_identificacion = new SqlParameter("TIPO_IDENTIFICACION", isNull(datos.Tipo_identificacion));
                SqlParameter Identificacion = new SqlParameter("IDENTIFICACION", int.Parse(datos.Identificacion.ToString()));
                SqlParameter Direccion = new SqlParameter("DIRECCION", isNull(datos.Direccion));
                SqlParameter Telefono = new SqlParameter("TELEFONO", isNull(datos.Telefono));
                SqlParameter Estado = new SqlParameter("ESTADO", Byte.Parse(datos.Estado.ToString()));
                SqlParameter contrasenna = new SqlParameter("CONTRASENNA", isNull(datos.contrasenna));
                SqlParameter operacion = new SqlParameter("OPERACION", int.Parse("0"));


                return context.EntityClienteResponseCrear.FromSqlRaw("EXEC[QRY].[CRUD_TblCLiente] " +
                    "@PERSONA_ID,@NOMBRE,@GENERO,@EDAD,@TIPO_IDENTIFICACION,@IDENTIFICACION,@DIRECCION,@TELEFONO,@ESTADO,@CONTRASENNA,@OPERACION",
                    Persona_ID, Nombre, Genero,Edad,Tipo_identificacion,Identificacion,Direccion,Telefono,Estado,contrasenna, operacion).ToList();
            }
            catch (Exception e)
            {
                RespuestaGenerica valor =  new RespuestaGenerica(){  Id = 0,Respuesta=e.Message.ToString(),Valor=0} ;
                var enumerable = new[] { valor };
                return enumerable;
            }
        }

        public IEnumerable<RespuestaGenerica> actualizarCliente(EntityClienteSP datos)
        {
            try
            {
                SqlParameter Persona_ID = new SqlParameter("PERSONA_ID", long.Parse(datos.PERSONA_ID.ToString()));
                SqlParameter Nombre = new SqlParameter("NOMBRE", isNull(datos.Nombre));
                SqlParameter Genero = new SqlParameter("GENERO", isNull(datos.Genero));
                SqlParameter Edad = new SqlParameter("EDAD", int.Parse(datos.Edad.ToString()));
                SqlParameter Tipo_identificacion = new SqlParameter("TIPO_IDENTIFICACION", isNull(datos.Tipo_identificacion));
                SqlParameter Identificacion = new SqlParameter("IDENTIFICACION", int.Parse(datos.Identificacion.ToString()));
                SqlParameter Direccion = new SqlParameter("DIRECCION", isNull(datos.Direccion));
                SqlParameter Telefono = new SqlParameter("TELEFONO", isNull(datos.Telefono));
                SqlParameter Estado = new SqlParameter("ESTADO", Byte.Parse(datos.Estado.ToString()));
                SqlParameter contrasenna = new SqlParameter("CONTRASENNA", isNull(datos.contrasenna));
                SqlParameter operacion = new SqlParameter("OPERACION", int.Parse("1"));


                return context.EntityClienteResponseCrear.FromSqlRaw("EXEC[QRY].[CRUD_TblCLiente] " +
                    "@PERSONA_ID,@NOMBRE,@GENERO,@EDAD,@TIPO_IDENTIFICACION,@IDENTIFICACION,@DIRECCION,@TELEFONO,@ESTADO,@CONTRASENNA,@OPERACION",
                    Persona_ID, Nombre, Genero, Edad, Tipo_identificacion, Identificacion, Direccion, Telefono, Estado, contrasenna, operacion).ToList();
            }
            catch (Exception e)
            {
                RespuestaGenerica valor = new RespuestaGenerica() { Id = 0, Respuesta = e.Message.ToString(), Valor = 0 };
                var enumerable = new[] { valor };
                return enumerable;
            }
        }

        public IEnumerable<RespuestaGenerica> EliminarCliente(int ID)
        {
            try
            {
                SqlParameter Persona_ID = new SqlParameter("PERSONA_ID", long.Parse(ID.ToString()));
                SqlParameter Nombre = new SqlParameter("NOMBRE", DBNull.Value);
                SqlParameter Genero = new SqlParameter("GENERO", DBNull.Value);
                SqlParameter Edad = new SqlParameter("EDAD", DBNull.Value);
                SqlParameter Tipo_identificacion = new SqlParameter("TIPO_IDENTIFICACION", DBNull.Value);
                SqlParameter Identificacion = new SqlParameter("IDENTIFICACION", DBNull.Value);
                SqlParameter Direccion = new SqlParameter("DIRECCION", DBNull.Value);
                SqlParameter Telefono = new SqlParameter("TELEFONO", DBNull.Value);
                SqlParameter Estado = new SqlParameter("ESTADO", DBNull.Value);
                SqlParameter contrasenna = new SqlParameter("CONTRASENNA", DBNull.Value);
                SqlParameter operacion = new SqlParameter("OPERACION", int.Parse("2"));


                return context.EntityClienteResponseCrear.FromSqlRaw("EXEC[QRY].[CRUD_TblCLiente] " +
                    "@PERSONA_ID,@NOMBRE,@GENERO,@EDAD,@TIPO_IDENTIFICACION,@IDENTIFICACION,@DIRECCION,@TELEFONO,@ESTADO,@CONTRASENNA,@OPERACION",
                    Persona_ID, Nombre, Genero, Edad, Tipo_identificacion, Identificacion, Direccion, Telefono, Estado, contrasenna, operacion).ToList();
            }
            catch (Exception e)
            {
                RespuestaGenerica valor = new RespuestaGenerica() { Id = 0, Respuesta = e.Message.ToString(), Valor = 0 };
                var enumerable = new[] { valor };
                return enumerable;
            }
        }

    }
}
