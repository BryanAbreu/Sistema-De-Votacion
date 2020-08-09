using AutoMapper;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Viewmodels;

namespace Proyecto_Final.Infrastructure.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            ConfigurePartido();
            ConfigureCiudadano();
            ConfigureCandidato();
        }
            
       
        private void ConfigurePartido()
        {
            CreateMap<PartidoViewModel,Partidos>().ReverseMap().ForMember(dest => dest.fotoPartido, opt => opt.Ignore()); ;
        }

        private void ConfigureCiudadano()
        {
            CreateMap<CiudadanoViewModel, Ciudadanos>().ReverseMap();
            CreateMap<Ciudadanos, CiudadanoViewModel>().ReverseMap();
        }

        private void ConfigureCandidato()
        {
            CreateMap<CadidatoViewModel, Cadidato>().ReverseMap().ForMember(dest => dest.fotoCandidato, opt => opt.Ignore()); ;
        }
    }
}
