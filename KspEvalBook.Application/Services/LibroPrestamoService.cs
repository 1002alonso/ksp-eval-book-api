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
    public class LibroPrestamoService : ILibroPrestamoService<LibroPrestamoDto, Guid>
    {
        private readonly IPrestamoLibroRepository<CbTabLibroPrestamo, Guid, Guid> _repositoryLibroPrestamo;
        private readonly IGenericReposiory<CbTabLibro, Guid> _repositoryLibro;
        private readonly IMapper _mapper;
        public LibroPrestamoService(IPrestamoLibroRepository<CbTabLibroPrestamo, Guid, Guid> repositoryLibroPrestamo, IMapper mapper, IGenericReposiory<CbTabLibro, Guid> repositoryLibro)
        {
            _repositoryLibroPrestamo = repositoryLibroPrestamo;
            _mapper = mapper;
            _repositoryLibro = repositoryLibro;
        }
        public LibroPrestamoDto Create(LibroPrestamoDto entidadDto)
        {
            var libro = new CbTabLibroPrestamo();
            libro.IdPrestamo = Guid.NewGuid();
            libro.FkLibro= entidadDto.fkLibro;
            libro.FkLibroUsuario = entidadDto.fkLibroUsuario;
            libro.FechaPrestamo = DateTime.UtcNow;
            libro.DtAlta = DateTime.UtcNow;
            libro.DtActualiza = DateTime.UtcNow;
            libro.UsuarioAlta = "System";

            _repositoryLibroPrestamo.Create(libro);

            return entidadDto;
        }

        public LibroPrestamoDto Read(Guid entidadId)
        {
            throw new NotImplementedException();
        }

        public List<LibroPrestamoDto> ReadAll()
        {
            throw new NotImplementedException();
        }

        public List<LibroPrestamoDto> ReadAllIdUser(Guid entidad)
        {
            List < LibroPrestamoDto > list= new List<LibroPrestamoDto>();
            List<CbTabLibroPrestamo> ListUserLibros = _repositoryLibroPrestamo.ReadAll(entidad);
            List<CbTabLibro> ListLibros = _repositoryLibro.ReadAll().ToList();

           var listUserLibro = from listUserLibros in ListUserLibros
                                   join listLibros in ListLibros
                                   on listUserLibros.FkLibro equals listLibros.IdLibro
                                   select new LibroPrestamoDto()
                                   {
                                       idPrestamo = listUserLibros.IdPrestamo,
                                       fkLibro= listUserLibros.FkLibro,
                                       fkLibroUsuario = listUserLibros.FkLibroUsuario,
                                       fechaPrestamo= listUserLibros.FechaPrestamo,
                                       fechaDevolucion = listUserLibros.FechaDevolucion,
                                       tituloLibro = listLibros.Titulo,
                                   };

            return listUserLibro.ToList();
        }

        

        public void Update(Guid entidadId, LibroPrestamoDto entidad)
        {
            CbTabLibroPrestamo updateLibroPrestamo = _repositoryLibroPrestamo.Read(entidadId);

            updateLibroPrestamo.FechaDevolucion= DateTime.UtcNow;
            updateLibroPrestamo.DtActualiza = DateTime.UtcNow;
            _repositoryLibroPrestamo.Update(updateLibroPrestamo);


        }

        public int ValidarLibro(LibroPrestamoDto entidad)
        {
            return _repositoryLibroPrestamo.CountBooks(entidad.fkLibro);
        }

        public int ValidarUsuarioLibro(LibroPrestamoDto entidad)
        {
            return _repositoryLibroPrestamo.CountBookUser(entidad.fkLibroUsuario,entidad.fkLibro);
        }
    }
}
