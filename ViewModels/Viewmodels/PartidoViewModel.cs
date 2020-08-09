using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Microsoft.AspNetCore.Http;

namespace ViewModels.Viewmodels
{
   public class PartidoViewModel
    {
        public int Id { get; set; }
        public string NombrePartido { get; set; }
        public string DescripcionPartido { get; set; }
        public string LogoPartido { get; set; }
        public bool Estado { get; set; }

        [Display(Name = "fotoPartido")]
        public IFormFile fotoPartido { get; set; }

        
    }
}
