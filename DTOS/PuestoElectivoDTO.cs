using System;
using System.Collections.Generic;
using System.Text;

namespace DTOS
{
    public class PuestoElectivoDTO
    {
        public int IdPuesto { get; set; }
        public string NombrePuesto { get; set; }
        public string DescripcionPuesto { get; set; }
        public bool Estado { get; set; }
    }
}
