using EntitiesNeoris;
using EntitiesNeoris.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataNeoris.Interfaces
{
    public interface IDataCuenta
    {
        IEnumerable<EntityCuentaResponse> ConsultarCuentas();
        IEnumerable<RespuestaGenerica> guardarCuenta(EntityCuentaSP datos);
        IEnumerable<EntityCuentaResponse> ConsultarCuentasXIdentificacion(int identificacion);
        IEnumerable<RespuestaGenerica> actualizarCuenta(EntityCuentaSP datos);
        IEnumerable<RespuestaGenerica> EliminarCuenta(int ID);

    }
}
