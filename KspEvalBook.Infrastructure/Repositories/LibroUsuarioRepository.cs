using KspEvalBook.Domain.Entities;
using KspEvalBook.Domain.Interfaces.Repositories;
using KspEvalBook.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Infrastructure.Repositories
{
    public class LibroUsuarioRepository : IGenericReposiory<CbTabLibroUsuario, Guid>
    {
        private readonly KspEvalBookDbContext _db;

        public LibroUsuarioRepository(KspEvalBookDbContext db)
        {
            _db = db;
        }
        public CbTabLibroUsuario Create(CbTabLibroUsuario entity)
        {
            _db.CbTabLibroUsuarios.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public void Delete(Guid entityId)
        {
            CbTabLibroUsuario libroUserOne = _db.CbTabLibroUsuarios.First(x => x.IdLibroUsuario == entityId);

            _db.CbTabLibroUsuarios.Remove(libroUserOne);
            _db.SaveChanges();
        }

        public CbTabLibroUsuario Read(Guid entityId)
        {
            var libroUserOne = _db.CbTabLibroUsuarios.Where(c => c.IdLibroUsuario == entityId).FirstOrDefault();
            return libroUserOne;
        }

        public IQueryable<CbTabLibroUsuario> ReadAll()
        {
            return _db.CbTabLibroUsuarios;
        }

        public void SavedAllChange()
        {
            throw new NotImplementedException();
        }

        public void Update(CbTabLibroUsuario entity)
        {
            _db.CbTabLibroUsuarios.Update(entity);
            _db.SaveChanges();
        }
    }
}
