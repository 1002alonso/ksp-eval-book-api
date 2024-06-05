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
    public class LibroFile: Profile
    {
        public LibroFile() { 
            CreateMap<CbTabLibro, LibroDto>()
                .ForMember(dest => dest.idLibro, opt => opt.MapFrom(src => src.IdLibro))
                .ForMember(dest => dest.folio, opt => opt.MapFrom(src => src.Folio))
                .ForMember(dest => dest.titulo, opt => opt.MapFrom(src => src.Titulo));
        
        }
    }
}
