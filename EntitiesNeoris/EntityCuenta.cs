using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntitiesNeoris
{
    public class EntityCuentaResponse
    {
        [Key]
        public long Cuenta_ID { get; set; }
        public string Numero_Cuenta { get; set; }
        public string Tipo_Cuenta { get; set; }
        public decimal saldo_Cuenta { get; set; }
        public byte Estado { get; set; }
        public string Nombre_persona { get; set; }
    }

    public class EntityCuentaSP
    {
        [Key]
        public long? Cuenta_ID { get; set; }
        public string TIPO_IDENTIFICACION { get; set; }
        public int IDENTIFICACION { get; set; }
        public string ENTIDAD { get; set; }
        public string N_CUENTA { get; set; }
        public string TIPO_CUENTA { get; set; }
        public decimal SALDO_INICIAL { get; set; }
        public byte Estado { get; set; }
        public string CONTRASENNA { get; set; }
    }


}
