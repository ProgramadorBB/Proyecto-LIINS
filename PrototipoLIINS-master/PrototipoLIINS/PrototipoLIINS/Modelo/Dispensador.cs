using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PrototipoLIINS.Modelo
{
    [Table("Dispensadores")]
    public class Dispensador
    {
        [PrimaryKey, MaxLength(20), Column("_nombreDispensador")]
        public string NombreDispensador { get; set; }
        [MaxLength(20)] public string Volumen { get; set; }
        [MaxLength(50)] public string Contenido { get; set; }
        public int ConsumoAcumulado { get; set; }
    }
}
