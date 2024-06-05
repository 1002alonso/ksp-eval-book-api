using Microsoft.EntityFrameworkCore;
using KspEvalBook.Domain.Entities;
using KspEvalBook.Infrastructure.Configurations;


namespace KspEvalBook.Infrastructure.Data
{
    public class KspEvalBookDbContext:DbContext
    {
        public KspEvalBookDbContext()
        {

        }

        public KspEvalBookDbContext(DbContextOptions<KspEvalBookDbContext> options): base(options) { }

        public DbSet<CbCatEditorial> CbCatEditorials { get; set; }
        public DbSet<CbTabLibro> CbTabLibros { get; set; }
        public DbSet<CbTabLibroPrestamo> CbTabLibroPrestamos { get; set; }
        public DbSet<CbTabUsuario> CbTabUsuarios { get; set; }
        public DbSet<CbTabLibroUsuario> CbTabLibroUsuarios { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CbCatEditorialConfig());
            modelBuilder.ApplyConfiguration(new CbTabLibroConfig());
            modelBuilder.ApplyConfiguration(new CbTabLibroPrestamoConfig());
            modelBuilder.ApplyConfiguration(new CbTabLibroUsuarioConfig());
            modelBuilder.ApplyConfiguration(new CbTabUsuarioConfig());
        }

        }
}
