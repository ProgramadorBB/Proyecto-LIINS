using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;

namespace PrototipoLIINS.Modelo
{
    [Table("liquidos")]
    public class Liquido
    {
        [PrimaryKey, MaxLength(50), Column("_nombreLiquido")]
        public string NombreLiquido { get; set; }
        [MaxLength(50)] public string Tipo { get; set; }
     }
}
