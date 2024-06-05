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
    public class LibroService : IGenericService<LibroDto, Guid>
    {
        private readonly IGenericReposiory<CbTabLibro, Guid> _repositoryLibro;
        private readonly IMapper _mapper;

        public LibroService(IGenericReposiory<CbTabLibro, Guid> repositoryLibro, IMapper mapper)
        {
            _repositoryLibro = repositoryLibro;
            _mapper = mapper;
        }
        public LibroDto Create(LibroDto libroDto)
        {
            var libro = new CbTabLibro();
            libro.IdLibro = Guid.NewGuid();
            libro.Folio = libroDto.folio;
            libro.Titulo = libroDto.titulo;
            libro.Descripcion = libroDto.descripcion;
            libro.Autor = libroDto.autor;
            libro.FkEditorial = libroDto.fkEditorial;
            libro.Anio = libroDto.anio;
            libro.NumCopias = libroDto.numCopias;
            libro.DtAlta = DateTime.UtcNow;
            libro.DtActualiza = DateTime.UtcNow;
            libro.UsuarioAlta = "System";
            _repositoryLibro.Create(libro);

            return libroDto;
        }

        public void Delete(Guid entidadId)
        {
            _repositoryLibro.Delete(entidadId);
        }

        public LibroDto Read(Guid entidadId)
        {
            CbTabLibro readLibro = _repositoryLibro.Read(entidadId);
            return _mapper.Map<LibroDto>(readLibro);
        }

        public List<LibroDto> ReadAll()
        {
            IQueryable<CbTabLibro> libros = _repositoryLibro.ReadAll();
            return _mapper.Map<List<LibroDto>>(libros);
        }

        public void Update(Guid entidadId, LibroDto libroDto)
        {
            CbTabLibro updateLibro = _repositoryLibro.Read(entidadId);
            updateLibro.Folio = libroDto.folio;
            updateLibro.Titulo = libroDto.titulo;
            updateLibro.Descripcion = libroDto.descripcion;
            updateLibro.Autor = libroDto.autor;
            updateLibro.FkEditorial = libroDto.fkEditorial;
            updateLibro.Anio = libroDto.anio;
            updateLibro.NumCopias = libroDto.numCopias;
            updateLibro.DtActualiza = DateTime.UtcNow;

            _repositoryLibro.Update(updateLibro);
        }
    }
}
