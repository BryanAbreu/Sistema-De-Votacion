using System;
using System.Collections.Generic;
using System.Text;

namespace DTOS
{
    public class EleccionesDTO
    {
        public int IdElecciones { get; set; }
        public string NombreEleciones { get; set; }
        public string Fecha { get; set; }
        public bool Estado { get; set; }
    }
}
