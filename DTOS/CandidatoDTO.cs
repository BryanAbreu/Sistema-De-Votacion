using System;
using System.Collections.Generic;
using System.Text;

namespace DTOS
{
    public class CandidatoDTO
    {
        public int IdCandidato { get; set; }
        public string NombreCandidato { get; set; }
        public string Apellido { get; set; }
        public string PartidoCandidato { get; set; }
        public string PuestoCandidato { get; set; }
        public bool Estado { get; set; }
        public string fotoCandidato { get; set; }
    }
}
