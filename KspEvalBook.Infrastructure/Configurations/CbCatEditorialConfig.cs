using KspEvalBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Infrastructure.Configurations
{
    class CbCatEditorialConfig : IEntityTypeConfiguration<CbCatEditorial>
    {
        public void Configure(EntityTypeBuilder<CbCatEditorial> entity)
        {
            entity.ToTable("CB_CAT_EDITORIAL");
            entity.HasKey(c => c.IdEditorial);

            entity.Property(e => e.IdEditorial)
               .HasMaxLength(36)
               .IsUnicode(false)
               .HasColumnName("ID_EDITORIAL");
            entity.Property(e => e.Nombre)
               .HasMaxLength(250)
               .IsUnicode(false)
               .HasColumnName("NOMBRE");
            entity.Property(e => e.DtAlta)
              .HasColumnType("datetime")
              .HasColumnName("DT_ALTA");
            entity.Property(e => e.DtActualiza)
             .HasColumnType("datetime")
             .HasColumnName("DT_ACTUALIZA");
            entity.Property(e => e.UsuarioAlta)
             .HasMaxLength(18)
             .IsUnicode(false)
             .HasColumnName("USUARIO_ALTA");

        }
    }
}
