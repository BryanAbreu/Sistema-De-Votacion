using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Database.Models;

using Repository.RepositoryBase;
using ViewModels.Viewmodels;

namespace Repository.Repository
{
    public class EleccionesRepository : RepositoryBase<Elecciones, proyectoFinalContext>
    {
        private new readonly proyectoFinalContext _context;
        public EleccionesRepository(proyectoFinalContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<EleccionesViewModel>> Index()
        {
            var all = await GetAll();
            var list = new List<EleccionesViewModel>();
            all.ForEach(item =>
            {
                var viewModel = new EleccionesViewModel
                {
                    IdElecciones = item.IdElecciones,
                    NombreEleciones = item.NombreEleciones,
                    Fecha = item.Fecha,
                    Estado = item.Estado
                };
                list.Add(viewModel);
            });
            return list;
        }
    }
}
