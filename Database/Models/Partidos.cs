using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Partidos
    {
        public int Id { get; set; }
        public string NombrePartido { get; set; }
        public string DescripcionPartido { get; set; }
        public string LogoPartido { get; set; }
        public bool Estado { get; set; }
    }
}
