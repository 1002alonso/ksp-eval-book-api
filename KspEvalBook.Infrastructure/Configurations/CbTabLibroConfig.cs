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
    class CbTabLibroConfig : IEntityTypeConfiguration<CbTabLibro>
    {
        public void Configure(EntityTypeBuilder<CbTabLibro> entity)
        {
            entity.ToTable("CB_TAB_LIBRO");
            entity.HasKey(c => c.IdLibro);

            entity.Property(e => e.IdLibro)
               .HasMaxLength(36)
               .IsUnicode(false)
               .HasColumnName("ID_LIBRO");
            entity.Property(e => e.Folio)
              .HasMaxLength(12)
              .IsUnicode(false)
              .HasColumnName("FOLIO");
            entity.Property(e => e.Titulo)
             .HasMaxLength(250)
             .IsUnicode(false)
             .HasColumnName("TITULO");
            entity.Property(e => e.Descripcion)
            .HasMaxLength(350)
            .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Autor)
            .HasMaxLength(250)
            .HasColumnName("AUTOR");
            entity.Property(e => e.FkEditorial)
               .HasMaxLength(36)
               .IsUnicode(false)
               .HasColumnName("FK_EDITORIAL");
            entity.Property(e => e.Anio)
             .HasColumnType("int")
             .HasColumnName("ANIO");
            entity.Property(e => e.NumCopias)
             .HasColumnType("int")
             .HasColumnName("NUM_COPIAS");
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
