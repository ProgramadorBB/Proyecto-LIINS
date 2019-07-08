using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PrototipoLIINS.Modelo
{
    [Table ("usuarios")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(100), Unique] public string User { get; set; }

        [MaxLength(100)] public string Contraseña { get; set; }

        [MaxLength(100)] public string Nombre { get; set; }

        [MaxLength(100)] public string Apellido { get; set; }

        [MaxLength(25)] public string Tipo { get; set; }

        [MaxLength(25)] public string Estado { get; set; }
    }
}
