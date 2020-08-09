using System;
using System.Collections.Generic;
using System.Text;

namespace DTOS
{
    public class CiudadanoDTO
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }
    }
}
