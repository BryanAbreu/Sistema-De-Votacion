using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Database.Models;
using DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Repository.RepositoryBase;
using ViewModels.Viewmodels;

namespace Repository.Repository
{
    public class PuestoRepository : RepositoryBase<PuestoElectivo, proyectoFinalContext>
    {
        private new readonly proyectoFinalContext _context;
        private readonly IMapper _mapper;
       
        public PuestoRepository(proyectoFinalContext context,IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
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
            var dto = _mapper.Map<PuestoElectivoDTO>(puestoViewModel);
            var puesto = _mapper.Map<PuestoElectivo>(dto);
            return await Add(puesto);
        }

        public PuestoViewModel Edit(int id)
        {
            var puesto = GetById(id);
            var viewModel = new PuestoViewModel
            {
                IdPuesto = puesto.Result.IdPuesto,
                NombrePuesto = puesto.Result.NombrePuesto,
                DescripcionPuesto = puesto.Result.DescripcionPuesto,
                Estado = puesto.Result.Estado
            };
            return viewModel;
        }

        public async Task<bool> Editar(PuestoViewModel viewModel)
        {
            var dto = _mapper.Map<PuestoElectivoDTO>(viewModel);
            var puesto = _mapper.Map<PuestoElectivo>(dto);
            if(await Update(puesto) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
