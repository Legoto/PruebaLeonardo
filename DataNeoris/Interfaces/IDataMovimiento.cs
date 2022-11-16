using EntitiesNeoris;
using EntitiesNeoris.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataNeoris.Interfaces
{
    public interface IDataMovimiento
    {
        IEnumerable<EntityMovimientoResponse> ConsultarMovimientos();
        IEnumerable<RespuestaGenerica> guardarMovimiento(EntityMovimientoSP datos);
        IEnumerable<EntityMovimientoResponse> ConsultarCuentasXNumerCuenta(string numerCuenta);
        IEnumerable<RespuestaGenerica> actualizarMovimiento(EntityMovimientoSP datos);
        IEnumerable<RespuestaGenerica> EliminarMovimiento(int ID);

    }
}
