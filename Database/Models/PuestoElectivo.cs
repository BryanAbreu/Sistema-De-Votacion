using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class PuestoElectivo
    {
        public int IdPuesto { get; set; }
        public string NombrePuesto { get; set; }
        public string DescripcionPuesto { get; set; }
        public bool Estado { get; set; }
    }
}
