using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Database.Models;
using DTOS;
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
                 LogoPartido=item.LogoPartido,
                 Estado = item.Estado
                });


            });
            return vm;
        }
        public async Task<bool> AddPartido(PartidoViewModel partidoViewModel,string uniqueName)
        {
           

            var dto = _mapper.Map<PartidoDTO>(partidoViewModel);
            dto.LogoPartido = uniqueName;
            var part = _mapper.Map <Partidos>(dto);



            await Add(part);
            return true;
        }

        public PartidoViewModel Editar(int id)
        {
            var partido = GetById(id);
            var viewModel = new PartidoViewModel
            {
                NombrePartido = partido.Result.NombrePartido,
                DescripcionPartido = partido.Result.DescripcionPartido,
                Estado = partido.Result.Estado,
                LogoPartido = partido.Result.LogoPartido
            };
            return viewModel;
        }

        public async Task<bool> Edit(PartidoViewModel viewModel,string uniqueName)
        {
            var dto = _mapper.Map<PartidoDTO>(viewModel);
            dto.LogoPartido = uniqueName;
            var part = _mapper.Map<Partidos>(dto);
            await Update(part);
            return true;
        }
    }
}
