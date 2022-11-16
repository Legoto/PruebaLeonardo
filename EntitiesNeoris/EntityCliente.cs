using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntitiesNeoris
{
    public class EntityClienteResponse
    {
        [Key]
        public long Persona_ID { get; set; }
        public string Nombre { get; set; }
        public string TipoIdentificacion { get; set; }
        public long Identificacion { get; set; }
        public string Direccion { get; set; }
        public string telefono { get; set; }
        public byte estado { get; set; }

    }

    public class EntityClienteDB
    {
        [Key]
        public long? PERSONA_ID { get; set; }
        public string Nombre { get; set; }
        public int Genero_ID { get; set; }
        public int Edad { get; set; }
        public int Tipo_identificacion_ID { get; set; }
        public int Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public byte Estado { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_modificacion { get; set; }
    }
    public class EntityClienteSP
    {
        [Key]
        public long? PERSONA_ID { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string Tipo_identificacion { get; set; }
        public int Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public byte Estado { get; set; }
        public string contrasenna { get; set; }
    }


}
