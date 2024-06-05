using AutoMapper;
using KspEvalBook.Application.DTOs;
using KspEvalBook.Application.Interfaces;
using KspEvalBook.Domain.Entities;
using KspEvalBook.Domain.Interfaces.Repositories;


namespace KspEvalBook.Application.Services
{
    public class LibroUsuarioService : IGenericService<LibroUsuarioDto, Guid>
    {
        private readonly IGenericReposiory<CbTabLibroUsuario, Guid> _repositoryLibroUser;
        private readonly IMapper _mapper;
        public LibroUsuarioService(IGenericReposiory<CbTabLibroUsuario, Guid> repositoryLibroUser, IMapper mapper)
        {
            _repositoryLibroUser = repositoryLibroUser;
            _mapper = mapper;
        }
        public LibroUsuarioDto Create(LibroUsuarioDto libroUsuarioDto)
        {
            var libroUsuario = new CbTabLibroUsuario();
            libroUsuario.IdLibroUsuario = Guid.NewGuid();
            libroUsuario.ClaveUsuario = libroUsuarioDto.claveUsuario;
            libroUsuario.Nombre = libroUsuarioDto.nombre;
            libroUsuario.Direccion = libroUsuarioDto.direccion;
            libroUsuario.Telefono = libroUsuarioDto.telefono;
            libroUsuario.DtAlta = DateTime.UtcNow;
            libroUsuario.DtActualiza = DateTime.UtcNow;
            libroUsuario.UsuarioAlta = "System";
            _repositoryLibroUser.Create(libroUsuario);

            return libroUsuarioDto;
        }

        public void Delete(Guid entidadId)
        {
            _repositoryLibroUser.Delete(entidadId);
        }

        public LibroUsuarioDto Read(Guid entidadId)
        {
            CbTabLibroUsuario readLibroUser  = _repositoryLibroUser.Read(entidadId);
            return _mapper.Map<LibroUsuarioDto>(readLibroUser);
        }

        public List<LibroUsuarioDto> ReadAll()
        {
            IQueryable<CbTabLibroUsuario> libroUsers = _repositoryLibroUser.ReadAll();
            return _mapper.Map<List<LibroUsuarioDto>>(libroUsers);
        }

        public void Update(Guid entidadId, LibroUsuarioDto libroUsuarioDto)
        {
            CbTabLibroUsuario readLibroUser = _repositoryLibroUser.Read(entidadId);
        
            readLibroUser.Nombre = libroUsuarioDto.nombre;
            readLibroUser.Direccion = libroUsuarioDto.direccion;
            readLibroUser.Telefono = libroUsuarioDto.telefono;
            readLibroUser.DtActualiza = DateTime.UtcNow;

            _repositoryLibroUser.Update(readLibroUser);
        }
    }
}
