using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;
using ViewModels.Viewmodels;

namespace Repository.Repository
{
    public class CiudadanoRepository : RepositoryBase<Ciudadanos, proyectoFinalContext>
    {
        private new readonly proyectoFinalContext _context;
        private readonly IMapper _mapper;
        public CiudadanoRepository(proyectoFinalContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<CiudadanoViewModel> GetCiudadanos()
        {

            var lisr = _context.Ciudadanos.ToList();
            List<CiudadanoViewModel> vm = new List<CiudadanoViewModel>();

            lisr.ForEach(item =>
            {
                vm.Add(new CiudadanoViewModel
                {
                Cedula=item.Cedula,
                Nombre=item.Nombre,
                Apellido= item.Apellido,
                Email=item.Email,
                Estado= item.Estado
                });


            });
            return vm;
        }
        public async Task<Ciudadanos> Addciudadano(CiudadanoViewModel ciudadanoViewModel)
        {
            var map = _mapper.Map<Ciudadanos>(ciudadanoViewModel);

            return await Add(map); 
        }

        public async Task<bool> Deletecuid(string cedula)
        {
            var vm = await _context.Ciudadanos.FirstOrDefaultAsync(x => x.Cedula == cedula);
            _context.Ciudadanos.Remove(vm);
            await _context.SaveChangesAsync();
            return true;


        }
        public  CiudadanoViewModel EditView( Ciudadanos ciudadanos)
        {
            var map = _mapper.Map<CiudadanoViewModel>(ciudadanos);
            return map;
        }

        public async Task<bool> Editar(CiudadanoViewModel viewModel)
        {
            
            var map = _mapper.Map<Ciudadanos>(viewModel);
            _context.Ciudadanos.Update(map);
            await _context.SaveChangesAsync();
            return true;
        }
    }
    
}
