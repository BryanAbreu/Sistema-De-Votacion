using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Database.Models;
using Repository.RepositoryBase;
using ViewModels.Viewmodels;

namespace Repository.Repository
{
  public  class PartidoRepository : RepositoryBase<Partidos,proyectoFinalContext>
    {
        private new readonly proyectoFinalContext _context;
        private readonly IMapper _mapper;
        public PartidoRepository(proyectoFinalContext context,IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;

        }
        public List<PartidoViewModel> Getpartidos()
        {

            var lisr = _context.Partidos.ToList();
            List<PartidoViewModel> vm = new List<PartidoViewModel>();

            lisr.ForEach(item =>
            {
                vm.Add(new PartidoViewModel
                {
                 Id= item.Id,
                 NombrePartido= item.NombrePartido,
                 DescripcionPartido= item.DescripcionPartido,
                 LogoPartido=item.LogoPartido
                });


            });
            return vm;
        }
        public async Task<bool> AddPartido(PartidoViewModel partidoViewModel,string uniqueName)
        {
           

            var part = _mapper.Map<Partidos>(partidoViewModel);
            part.LogoPartido = uniqueName;



            await Add(part);
            return true;
        }
    }
}
