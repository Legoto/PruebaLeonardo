using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesNeoris.Response
{
    public class Respuesta
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }

        public object Data { get; set; }

    }


    public class RespuestaGenerica
    {
        public int Id { get; set; }
        public string Respuesta { get; set; }
        public long Valor { get; set; }

    }
}
