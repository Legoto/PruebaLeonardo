using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntitiesNeoris
{
    public class EntityReporteResponse
    {
        [Key]
        public long Cuenta_ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string Numero_Cuenta { get; set; }
        public string Tipo { get; set; }
        public byte Estado { get; set; }
        public decimal Movimiento { get; set; }
        public decimal Saldo_Disponible { get; set; }
    }



}
