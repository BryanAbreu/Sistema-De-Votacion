using AutoMapper;
using Database.Models;
using DTOS;
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
            ConfigurePuesto();
        }
            
       
        private void ConfigurePartido()
        {
            CreateMap<PartidoViewModel,PartidoDTO>().ReverseMap().ForMember(dest => dest.fotoPartido, opt => opt.Ignore()); ;
            CreateMap<PartidoDTO, Partidos>().ReverseMap();
            
        }

        private void ConfigureCiudadano()
        {
            CreateMap<CiudadanoViewModel, CiudadanoDTO>().ReverseMap();
            CreateMap<CiudadanoDTO, Ciudadanos>().ReverseMap();
            CreateMap<Ciudadanos, CiudadanoViewModel>().ReverseMap();
        }

        private void ConfigureCandidato()
        {
            CreateMap<CadidatoViewModel, CandidatoDTO>().ReverseMap().ForMember(dest => dest.fotoCandidato, opt => opt.Ignore()); ;
            CreateMap<CandidatoDTO, Cadidato>().ReverseMap();
        }

        private void ConfigurePuesto()
        {
            CreateMap<PuestoViewModel, PuestoElectivoDTO>().ReverseMap();
            CreateMap<PuestoElectivoDTO, PuestoElectivo>().ReverseMap();
        }
    }
}
