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
    public class LibroRepository : IGenericReposiory<CbTabLibro, Guid>
    {
        private readonly KspEvalBookDbContext _db;
        public LibroRepository(KspEvalBookDbContext db)
        {
            _db = db;
        }
        public CbTabLibro Create(CbTabLibro entity)
        {
            _db.CbTabLibros.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public void Delete(Guid entityId)
        {
            CbTabLibro libroOne = _db.CbTabLibros.First(x => x.IdLibro == entityId);

            _db.CbTabLibros.Remove(libroOne);
            _db.SaveChanges();
        }

        public CbTabLibro Read(Guid entityId)
        {
            var libroOne = _db.CbTabLibros.Where(c => c.IdLibro == entityId).FirstOrDefault();
            return libroOne;
        }

        public IQueryable<CbTabLibro> ReadAll()
        {
            return _db.CbTabLibros;
        }

        public void SavedAllChange()
        {
            throw new NotImplementedException();
        }

        public void Update(CbTabLibro entity)
        {
            _db.CbTabLibros.Update(entity);
            _db.SaveChanges();
        }
    }
}
