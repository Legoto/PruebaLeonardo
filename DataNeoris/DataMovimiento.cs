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

    public class DataMovimiento : IDataMovimiento
    {
        private readonly AppDbContext context;
        public DataMovimiento(AppDbContext context)
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

        public IEnumerable<EntityMovimientoResponse> ConsultarMovimientos()
        {

            SqlParameter operacion = new SqlParameter("OPERACION", 3);
            return context.EntityMovimientoResponse.FromSqlRaw("EXEC[QRY].[CRUD_TblMovimientos] @OPERACION",
              operacion).ToList();
        }
        public IEnumerable<RespuestaGenerica> guardarMovimiento(EntityMovimientoSP datos)
        {
            try
            {

                SqlParameter MOVIMIENTO_ID = new SqlParameter("MOVIMIENTO_ID", DBNull.Value);
                SqlParameter TIPO_MOVIMIENTO = new SqlParameter("TIPO_MOVIMIENTO", isNull(datos.TIPO_MOVIMIENTO));
                SqlParameter NUMERO_CUENTA = new SqlParameter("NUMERO_CUENTA", isNull(datos.NUMERO_CUENTA));
                SqlParameter VALOR = new SqlParameter("VALOR", decimal.Parse(datos.VALOR.ToString()));
                SqlParameter OPERACION = new SqlParameter("OPERACION", int.Parse("0"));


                return context.EntityMovimientoCrear.FromSqlRaw("EXEC[QRY].[CRUD_TblMovimientos] " +
                    "@MOVIMIENTO_ID,@TIPO_MOVIMIENTO,@NUMERO_CUENTA,@VALOR,@OPERACION",
                    MOVIMIENTO_ID, TIPO_MOVIMIENTO, NUMERO_CUENTA, VALOR, OPERACION).ToList();

            }
            catch (Exception e)
            {
                RespuestaGenerica valor =  new RespuestaGenerica(){  Id = 0,Respuesta=e.Message.ToString(),Valor=0} ;
                var enumerable = new[] { valor };
                return enumerable;
            }
        }

        public IEnumerable<EntityMovimientoResponse> ConsultarCuentasXNumerCuenta(string numerCuenta)
        {
            SqlParameter MOVIMIENTO_ID = new SqlParameter("MOVIMIENTO_ID", DBNull.Value);
            SqlParameter TIPO_MOVIMIENTO = new SqlParameter("TIPO_MOVIMIENTO", DBNull.Value);
            SqlParameter NUMERO_CUENTA = new SqlParameter("NUMERO_CUENTA", isNull(numerCuenta));
            SqlParameter VALOR = new SqlParameter("VALOR", DBNull.Value);
            SqlParameter OPERACION = new SqlParameter("OPERACION", int.Parse("4"));

            return context.EntityMovimientoResponse.FromSqlRaw("EXEC[QRY].[CRUD_TblMovimientos] " +
                "@MOVIMIENTO_ID,@TIPO_MOVIMIENTO,@NUMERO_CUENTA,@VALOR,@OPERACION",
                MOVIMIENTO_ID, TIPO_MOVIMIENTO, NUMERO_CUENTA, VALOR, OPERACION).ToList();
        }

        public IEnumerable<RespuestaGenerica> actualizarMovimiento(EntityMovimientoSP datos)
        {
            try
            {
                SqlParameter MOVIMIENTO_ID = new SqlParameter("MOVIMIENTO_ID", long.Parse(datos.MOVIMIENTO_ID.ToString()));
                SqlParameter TIPO_MOVIMIENTO = new SqlParameter("TIPO_MOVIMIENTO", isNull(datos.TIPO_MOVIMIENTO));
                SqlParameter NUMERO_CUENTA = new SqlParameter("NUMERO_CUENTA", isNull(datos.NUMERO_CUENTA));
                SqlParameter VALOR = new SqlParameter("VALOR", decimal.Parse(datos.VALOR.ToString()));
                SqlParameter OPERACION = new SqlParameter("OPERACION", int.Parse("1"));


                return context.EntityMovimientoCrear.FromSqlRaw("EXEC[QRY].[CRUD_TblMovimientos] " +
                    "@MOVIMIENTO_ID,@TIPO_MOVIMIENTO,@NUMERO_CUENTA,@VALOR,@OPERACION",
                    MOVIMIENTO_ID, TIPO_MOVIMIENTO, NUMERO_CUENTA, VALOR, OPERACION).ToList();
            }
            catch (Exception e)
            {
                RespuestaGenerica valor = new RespuestaGenerica() { Id = 0, Respuesta = e.Message.ToString(), Valor = 0 };
                var enumerable = new[] { valor };
                return enumerable;
            }
        }

        public IEnumerable<RespuestaGenerica> EliminarMovimiento(int ID)
        {
            try
            {
                SqlParameter MOVIMIENTO_ID = new SqlParameter("MOVIMIENTO_ID", long.Parse(ID.ToString()));
                SqlParameter TIPO_MOVIMIENTO = new SqlParameter("TIPO_MOVIMIENTO", DBNull.Value);
                SqlParameter NUMERO_CUENTA = new SqlParameter("NUMERO_CUENTA", DBNull.Value);
                SqlParameter VALOR = new SqlParameter("VALOR", DBNull.Value);
                SqlParameter OPERACION = new SqlParameter("OPERACION", int.Parse("2"));


                return context.EntityMovimientoCrear.FromSqlRaw("EXEC[QRY].[CRUD_TblMovimientos] " +
                    "@MOVIMIENTO_ID,@TIPO_MOVIMIENTO,@NUMERO_CUENTA,@VALOR,@OPERACION",
                    MOVIMIENTO_ID, TIPO_MOVIMIENTO, NUMERO_CUENTA, VALOR, OPERACION).ToList();
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
