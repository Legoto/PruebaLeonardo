using EntitiesNeoris;
using EntitiesNeoris.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataNeoris.Interfaces
{
    public interface IDataReportes
    {
        IEnumerable<EntityReporteResponse> ConsultarReporteXFecha(DateTime fecha_inicio, DateTime fecha_fin);

    }
}
