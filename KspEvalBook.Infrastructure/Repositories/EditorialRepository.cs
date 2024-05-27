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
    public class EditorialRepository : IGenericReposiory<CbCatEditorial, Guid>
    {
        private readonly KspEvalBookDbContext _db;

        public EditorialRepository(KspEvalBookDbContext db)
        {
            _db = db;
        }
        public CbCatEditorial Create(CbCatEditorial entidad)
        {

            _db.CbCatEditorials.Add(entidad);
            _db.SaveChanges();
            return entidad;
        }

        public void Delete(Guid entidadId)
        {
            CbCatEditorial editorialOne = _db.CbCatEditorials.First(x => x.IdEditorial == entidadId);

            _db.CbCatEditorials.Remove(editorialOne);
            _db.SaveChanges();

        }

        public void Update(CbCatEditorial entidad)
        {

            _db.CbCatEditorials.Update(entidad);
            _db.SaveChanges();
        }

        public CbCatEditorial Read(Guid entidadId)
        {
            var editorialOne = _db.CbCatEditorials.Where(c => c.IdEditorial == entidadId).FirstOrDefault();
            return editorialOne;
           
        }

        public IQueryable<CbCatEditorial> ReadAll()
        {
            return _db.CbCatEditorials;
        }

        public void SavedAllChange()
        {
            throw new NotImplementedException();
        }
    }
}
