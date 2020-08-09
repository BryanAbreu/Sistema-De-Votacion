using System;
using System.Collections.Generic;
using System.Text;

namespace DTOS
{
    public class PartidoDTO
    {
        public int Id { get; set; }
        public string NombrePartido { get; set; }
        public string DescripcionPartido { get; set; }
        public string LogoPartido { get; set; }
        public bool Estado { get; set; }
    }
}
