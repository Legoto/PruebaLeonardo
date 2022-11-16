using EntitiesNeoris;
using EntitiesNeoris.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataNeoris.Interfaces
{
    public interface IDataCliente
    {
        IEnumerable<EntityClienteResponse> ConsultarClientes();
        IEnumerable<EntityClienteResponse> ConsultarClienteXIdentificacion(int identificacion);
        IEnumerable<RespuestaGenerica> guardarCliente(EntityClienteSP datos);
        IEnumerable<RespuestaGenerica> actualizarCliente(EntityClienteSP datos);
        IEnumerable<RespuestaGenerica> EliminarCliente(int ID);


    }
}
