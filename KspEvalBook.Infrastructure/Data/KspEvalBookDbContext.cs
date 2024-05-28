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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CbCatEditorialConfig());
        }

        }
}
