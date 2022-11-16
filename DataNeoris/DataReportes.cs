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

    public class DataReportes : IDataReportes
    {
        private readonly AppDbContext context;
        public DataReportes(AppDbContext context)
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

        public IEnumerable<EntityReporteResponse> ConsultarReporteXFecha(DateTime fecha_inicio, DateTime fecha_fin)
        {
            SqlParameter FECHA_INICIO = new SqlParameter("FECHA_INICIO", fecha_inicio);
            SqlParameter FECHA_FIN = new SqlParameter("FECHA_FIN", fecha_fin);

            return context.EntityReportes.FromSqlRaw("EXEC[QRY].[QRY_Reporte] " +
                "@FECHA_INICIO,@FECHA_FIN",
                FECHA_INICIO, FECHA_FIN).ToList();
        }


    }
}
