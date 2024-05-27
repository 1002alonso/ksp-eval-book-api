using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KspEvalBook.Application.DTOs;
using KspEvalBook.Domain.Entities;

namespace KspEvalBook.Application.Mapper
{
    public class EditorialFile : Profile
    {
        public EditorialFile()
        {
            CreateMap<CbCatEditorial, EditorialDto>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.IdEditorial))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.Nombre));
        }
    }
}
