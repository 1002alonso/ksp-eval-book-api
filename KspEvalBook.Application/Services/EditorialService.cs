
using AutoMapper;
using KspEvalBook.Application.DTOs;
using KspEvalBook.Application.Interfaces;
using KspEvalBook.Domain.Entities;
using KspEvalBook.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Application.Services
{
    public class EditorialService : IGenericService<EditorialDto, Guid>
    {
        private readonly IGenericReposiory<CbCatEditorial, Guid> _repositoryEditorial;

        private readonly IMapper _mapper;

        public EditorialService(IGenericReposiory<CbCatEditorial, Guid> repositoryEditorial, IMapper mapper)
        {
            _repositoryEditorial = repositoryEditorial;
            _mapper= mapper;
        }

        public EditorialDto Create(EditorialDto editorialDto)
        {
             var editorial = new CbCatEditorial();
            editorial.IdEditorial = Guid.NewGuid();
            editorial.Nombre = editorialDto.nombre;
            editorial.DtAlta = DateTime.UtcNow;
            editorial.DtActualiza = DateTime.UtcNow;
            editorial.UsuarioAlta= "System";

            var newEditorial = _repositoryEditorial.Create(editorial);

          
            return editorialDto;

        }

        public void Delete(Guid entidadId)
        {
            _repositoryEditorial.Delete(entidadId);
        }

        public void Update(Guid entidadId, EditorialDto entidad)
        {
            CbCatEditorial updateEditorial = _repositoryEditorial.Read(entidadId);

            updateEditorial.Nombre= entidad.nombre;
            updateEditorial.DtActualiza = DateTime.UtcNow;
            _repositoryEditorial.Update(updateEditorial);


        }

        public EditorialDto Read(Guid entidadId)
        {
            CbCatEditorial readEditorial = _repositoryEditorial.Read(entidadId);

            return _mapper.Map<EditorialDto>(readEditorial);

        }

        public List<EditorialDto> ReadAll()
        {
            IQueryable<CbCatEditorial> editorials = _repositoryEditorial.ReadAll();
            return _mapper.Map<List<EditorialDto>>(editorials);


        }
    }
}
