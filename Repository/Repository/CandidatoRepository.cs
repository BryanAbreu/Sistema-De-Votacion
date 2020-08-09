using AutoMapper;
using Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ViewModels.Viewmodels;


namespace Repository.Repository
{
    public class CandidatoRepository : RepositoryBase<Cadidato, proyectoFinalContext>
    {
        private new  readonly proyectoFinalContext _context;
        private readonly IMapper _mapper;
        public CandidatoRepository(proyectoFinalContext context,IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<CadidatoViewModel> GetCadidatos()
        {
            
            var lisr = _context.Cadidato.ToList();
            List<CadidatoViewModel> vm = new List<CadidatoViewModel>();

            lisr.ForEach(item =>
            {
                vm.Add(new CadidatoViewModel
                {
                    IdCandidato= item.IdCandidato,
                    NombreCandidato = item.NombreCandidato,
                    Apellido = item.Apellido,
                    PartidoCandidato = item.PartidoCandidato,
                    PuestoCandidato = item.PuestoCandidato,
                    foto = item.fotoCandidato
                });


            });
            return vm;
        }
        public async Task<bool> Addcandidato(CadidatoViewModel cadidatoViewModel,string foto)
        {

            var map = _mapper.Map<Cadidato>(cadidatoViewModel);
            map.fotoCandidato = foto;
            await Add(map);
            return true;
        }
    }
}

