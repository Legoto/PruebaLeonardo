using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntitiesNeoris
{
    public class EntityMovimientoResponse
    {
        [Key]
        public long Movimiento_ID { get; set; }
        public string Numero_Cuenta { get; set; }
        public string Tipo_Cuenta { get; set; }
        public decimal Saldo_inicial { get; set; }
        public byte Estado { get; set; }
        public string Descripcion { get; set; }
    }

    public class EntityMovimientoSP
    {
        [Key]
        public long? MOVIMIENTO_ID { get; set; }
        public string TIPO_MOVIMIENTO { get; set; }
        public string NUMERO_CUENTA { get; set; }
        public decimal VALOR { get; set; }
        
    }


}
