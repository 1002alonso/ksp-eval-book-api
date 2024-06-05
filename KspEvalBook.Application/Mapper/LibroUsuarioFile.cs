using AutoMapper;
using KspEvalBook.Application.DTOs;
using KspEvalBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Application.Mapper
{
    public class LibroUsuarioFile : Profile
    {
        public LibroUsuarioFile()
        {
            CreateMap<CbTabLibroUsuario, LibroUsuarioDto>()
                .ForMember(dest => dest.idLibroUsuario, opt => opt.MapFrom(src => src.IdLibroUsuario))
                .ForMember(dest => dest.claveUsuario, opt => opt.MapFrom(src => src.ClaveUsuario))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.Nombre));

        }
    }
}
