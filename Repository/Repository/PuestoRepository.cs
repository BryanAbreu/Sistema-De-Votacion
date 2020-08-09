using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Repository.RepositoryBase;
using ViewModels.Viewmodels;

namespace Repository.Repository
{
    public class PuestoRepository : RepositoryBase<PuestoElectivo, proyectoFinalContext>
    {
        private new readonly proyectoFinalContext _context;
        
       
        public PuestoRepository(proyectoFinalContext context) : base(context)
        {
            _context = context;
        }
        public List<PuestoViewModel> GetPuestos()
        {

            var lisr = _context.PuestoElectivo.ToList();
            List<PuestoViewModel> vm = new List<PuestoViewModel>();

            lisr.ForEach(item =>
            {
                vm.Add(new PuestoViewModel
                {
                    IdPuesto= item.IdPuesto,
                    NombrePuesto= item.NombrePuesto,
                    DescripcionPuesto= item.DescripcionPuesto,
                    Estado= item.Estado
                });


            });
            return vm;
        }
        public async Task<PuestoElectivo> AddPuesto(PuestoViewModel puestoViewModel)
        {
            var puesto = new PuestoElectivo
            {
                NombrePuesto = puestoViewModel.NombrePuesto,
                DescripcionPuesto = puestoViewModel.DescripcionPuesto,
                Estado = puestoViewModel.Estado
            };
          
            return   await Add(puesto);  ; 
        }
    }
}
