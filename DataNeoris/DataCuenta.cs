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

    public class DataCuenta : IDataCuenta
    {
        private readonly AppDbContext context;
        public DataCuenta(AppDbContext context)
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
        public IEnumerable<EntityCuentaResponse> ConsultarCuentas()
        {

            SqlParameter operacion = new SqlParameter("OPERACION", 3);
            return context.EntityCuentaResponse.FromSqlRaw("EXEC[QRY].[CRUD_TblCuentas] @OPERACION",
              operacion).ToList();
        }

        public IEnumerable<RespuestaGenerica> guardarCuenta(EntityCuentaSP datos)
        {
            try
            {

                SqlParameter Cuenta_ID = new SqlParameter("Cuenta_ID", DBNull.Value);
                SqlParameter TIPO_IDENTIFICACION = new SqlParameter("TIPO_IDENTIFICACION", isNull(datos.TIPO_IDENTIFICACION));
                SqlParameter IDENTIFICACION = new SqlParameter("IDENTIFICACION", int.Parse(datos.IDENTIFICACION.ToString()));
                SqlParameter ENTIDAD = new SqlParameter("ENTIDAD", isNull(datos.ENTIDAD));
                SqlParameter N_CUENTA = new SqlParameter("N_CUENTA", isNull(datos.N_CUENTA));
                SqlParameter TIPO_CUENTA = new SqlParameter("TIPO_CUENTA", isNull(datos.TIPO_CUENTA));
                SqlParameter SALDO_INICIAL = new SqlParameter("SALDO_INICIAL", decimal.Parse(datos.SALDO_INICIAL.ToString()));
                SqlParameter Estado = new SqlParameter("ESTADO", Byte.Parse(datos.Estado.ToString()));
                SqlParameter contrasenna = new SqlParameter("CONTRASENNA", isNull(datos.CONTRASENNA));
                SqlParameter operacion = new SqlParameter("OPERACION", int.Parse("0"));


                return context.EntityClienteResponseCrear.FromSqlRaw("EXEC[QRY].[CRUD_TblCuentas] " +
                    "@CUENTA_ID,@TIPO_IDENTIFICACION,@IDENTIFICACION,@ENTIDAD,@N_CUENTA,@TIPO_CUENTA,@SALDO_INICIAL,@ESTADO,@CONTRASENNA,@OPERACION",
                    Cuenta_ID, TIPO_IDENTIFICACION, IDENTIFICACION,ENTIDAD,N_CUENTA,TIPO_CUENTA,SALDO_INICIAL,Estado,contrasenna, operacion).ToList();

            }
            catch (Exception e)
            {
                RespuestaGenerica valor =  new RespuestaGenerica(){  Id = 0,Respuesta=e.Message.ToString(),Valor=0} ;
                var enumerable = new[] { valor };
                return enumerable;
            }
        }

        public IEnumerable<EntityCuentaResponse> ConsultarCuentasXIdentificacion(int identificacion)
        {


            SqlParameter Cuenta_ID = new SqlParameter("Cuenta_ID", DBNull.Value);
            SqlParameter TIPO_IDENTIFICACION = new SqlParameter("TIPO_IDENTIFICACION", DBNull.Value);
            SqlParameter IDENTIFICACION = new SqlParameter("IDENTIFICACION", int.Parse(identificacion.ToString()));
            SqlParameter ENTIDAD = new SqlParameter("ENTIDAD", DBNull.Value);
            SqlParameter N_CUENTA = new SqlParameter("N_CUENTA", DBNull.Value);
            SqlParameter TIPO_CUENTA = new SqlParameter("TIPO_CUENTA", DBNull.Value);
            SqlParameter SALDO_INICIAL = new SqlParameter("SALDO_INICIAL", DBNull.Value);
            SqlParameter Estado = new SqlParameter("ESTADO", DBNull.Value);
            SqlParameter contrasenna = new SqlParameter("CONTRASENNA", DBNull.Value);
            SqlParameter operacion = new SqlParameter("OPERACION", int.Parse("4"));


            return context.EntityCuentaResponse.FromSqlRaw("EXEC[QRY].[CRUD_TblCuentas] " +
                "@CUENTA_ID,@TIPO_IDENTIFICACION,@IDENTIFICACION,@ENTIDAD,@N_CUENTA,@TIPO_CUENTA,@SALDO_INICIAL,@ESTADO,@CONTRASENNA,@OPERACION",
                Cuenta_ID, TIPO_IDENTIFICACION, IDENTIFICACION, ENTIDAD, N_CUENTA, TIPO_CUENTA, SALDO_INICIAL, Estado, contrasenna, operacion).ToList();


        }

        public IEnumerable<RespuestaGenerica> actualizarCuenta(EntityCuentaSP datos)
        {
            try
            {
                SqlParameter Cuenta_ID = new SqlParameter("Cuenta_ID", long.Parse(datos.Cuenta_ID.ToString()));
                SqlParameter TIPO_IDENTIFICACION = new SqlParameter("TIPO_IDENTIFICACION", isNull(datos.TIPO_IDENTIFICACION));
                SqlParameter IDENTIFICACION = new SqlParameter("IDENTIFICACION", int.Parse(datos.IDENTIFICACION.ToString()));
                SqlParameter ENTIDAD = new SqlParameter("ENTIDAD", isNull(datos.ENTIDAD));
                SqlParameter N_CUENTA = new SqlParameter("N_CUENTA", isNull(datos.N_CUENTA));
                SqlParameter TIPO_CUENTA = new SqlParameter("TIPO_CUENTA", isNull(datos.TIPO_CUENTA));
                SqlParameter SALDO_INICIAL = new SqlParameter("SALDO_INICIAL", decimal.Parse(datos.SALDO_INICIAL.ToString()));
                SqlParameter Estado = new SqlParameter("ESTADO", Byte.Parse(datos.Estado.ToString()));
                SqlParameter contrasenna = new SqlParameter("CONTRASENNA", isNull(datos.CONTRASENNA));
                SqlParameter operacion = new SqlParameter("OPERACION", int.Parse("1"));
                
                return context.EntityClienteResponseCrear.FromSqlRaw("EXEC[QRY].[CRUD_TblCuentas] " +
                    "@CUENTA_ID,@TIPO_IDENTIFICACION,@IDENTIFICACION,@ENTIDAD,@N_CUENTA,@TIPO_CUENTA,@SALDO_INICIAL,@ESTADO,@CONTRASENNA,@OPERACION",
                    Cuenta_ID, TIPO_IDENTIFICACION, IDENTIFICACION,ENTIDAD,N_CUENTA,TIPO_CUENTA,SALDO_INICIAL,Estado,contrasenna, operacion).ToList();

            }
            catch (Exception e)
            {
                RespuestaGenerica valor = new RespuestaGenerica() { Id = 0, Respuesta = e.Message.ToString(), Valor = 0 };
                var enumerable = new[] { valor };
                return enumerable;
            }
        }

        public IEnumerable<RespuestaGenerica> EliminarCuenta(int ID)
        {
            try
            {
                SqlParameter Cuenta_ID = new SqlParameter("Cuenta_ID", long.Parse(ID.ToString()));
                SqlParameter TIPO_IDENTIFICACION = new SqlParameter("TIPO_IDENTIFICACION", DBNull.Value);
                SqlParameter IDENTIFICACION = new SqlParameter("IDENTIFICACION", DBNull.Value);
                SqlParameter ENTIDAD = new SqlParameter("ENTIDAD", DBNull.Value);
                SqlParameter N_CUENTA = new SqlParameter("N_CUENTA", DBNull.Value);
                SqlParameter TIPO_CUENTA = new SqlParameter("TIPO_CUENTA", DBNull.Value);
                SqlParameter SALDO_INICIAL = new SqlParameter("SALDO_INICIAL", DBNull.Value);
                SqlParameter Estado = new SqlParameter("ESTADO", DBNull.Value);
                SqlParameter contrasenna = new SqlParameter("CONTRASENNA", DBNull.Value);
                SqlParameter operacion = new SqlParameter("OPERACION", int.Parse("2"));

                return context.EntityClienteResponseCrear.FromSqlRaw("EXEC[QRY].[CRUD_TblCuentas] " +
                    "@CUENTA_ID,@TIPO_IDENTIFICACION,@IDENTIFICACION,@ENTIDAD,@N_CUENTA,@TIPO_CUENTA,@SALDO_INICIAL,@ESTADO,@CONTRASENNA,@OPERACION",
                    Cuenta_ID, TIPO_IDENTIFICACION, IDENTIFICACION, ENTIDAD, N_CUENTA, TIPO_CUENTA, SALDO_INICIAL, Estado, contrasenna, operacion).ToList();
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
