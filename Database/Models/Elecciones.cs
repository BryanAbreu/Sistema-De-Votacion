using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Elecciones
    {
        public int IdElecciones { get; set; }
        public string NombreEleciones { get; set; }
        public string Fecha { get; set; }
        public bool Estado { get; set; }
    }
}
