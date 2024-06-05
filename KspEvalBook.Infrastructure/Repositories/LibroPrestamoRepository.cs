using KspEvalBook.Domain.Entities;
using KspEvalBook.Domain.Interfaces.Repositories;
using KspEvalBook.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Infrastructure.Repositories
{
    public class LibroPrestamoRepository : IPrestamoLibroRepository<CbTabLibroPrestamo, Guid, Guid>
    {
        private readonly KspEvalBookDbContext _db;
        public LibroPrestamoRepository(KspEvalBookDbContext db)
        {
            _db = db;
        }
        public int CountBooks(Guid bookId)
        {
            return _db.CbTabLibroPrestamos.Where(c => c.FkLibro == bookId && c.FechaDevolucion == null).Count();
   
        }

        public int CountBookUser(Guid userBookId, Guid bookId)
        {
            return _db.CbTabLibroPrestamos.Where(c => c.FkLibro == bookId && c.FkLibroUsuario == userBookId && c.FechaDevolucion == null).Count();
        }

        public CbTabLibroPrestamo Create(CbTabLibroPrestamo cbTabLibroPrestamo)
        {
            _db.CbTabLibroPrestamos.Add(cbTabLibroPrestamo);
            _db.SaveChanges();
            return cbTabLibroPrestamo;
        }

        public CbTabLibroPrestamo Read(Guid id)
        {
            var prestamoLibro = _db.CbTabLibroPrestamos.Where(c => c.IdPrestamo == id).FirstOrDefault();
            return prestamoLibro;

          
        }

        public IQueryable<CbTabLibroPrestamo> ReadAll()
        {
            throw new NotImplementedException();
        }

        public List<CbTabLibroPrestamo> ReadAll(Guid userBookId)
        {
            var listLibroPrestamo = _db.CbTabLibroPrestamos.Where(c => c.FkLibroUsuario == userBookId && c.FechaDevolucion==null);


            return listLibroPrestamo.ToList();
        }

        public void Update(CbTabLibroPrestamo cbTabLibroPrestamo)
        {
            _db.CbTabLibroPrestamos.Update(cbTabLibroPrestamo);
            _db.SaveChanges();
        }
    }
}
