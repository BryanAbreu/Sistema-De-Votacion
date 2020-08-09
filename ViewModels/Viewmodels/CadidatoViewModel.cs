using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ViewModels.Viewmodels
{
   public class CadidatoViewModel
    {
        public int IdCandidato { get; set; }
        public string NombreCandidato { get; set; }
        public string Apellido { get; set; }
        public string PartidoCandidato { get; set; }
        public string PuestoCandidato { get; set; }
        public bool Estado { get; set; }
        public IFormFile fotoCandidato { get; set; }

        public string foto { get; set; }

       
    }
}
