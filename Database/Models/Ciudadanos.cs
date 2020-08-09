using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Ciudadanos
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }
    }
}
