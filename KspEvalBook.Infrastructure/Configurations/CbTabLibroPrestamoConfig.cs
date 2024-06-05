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
    class CbTabLibroPrestamoConfig : IEntityTypeConfiguration<CbTabLibroPrestamo>
    {
        public void Configure(EntityTypeBuilder<CbTabLibroPrestamo> entity)
        {
            entity.ToTable("CB_TAB_LIBRO_PRESTAMO");
            entity.HasKey(c => c.IdPrestamo);

            entity.Property(e => e.IdPrestamo)
              .HasMaxLength(36)
              .IsUnicode(false)
              .HasColumnName("ID_PRESTAMO");
            entity.Property(e => e.FkLibro)
             .HasMaxLength(36)
             .IsUnicode(false)
             .HasColumnName("FK_LIBRO");
            entity.Property(e => e.FkLibroUsuario)
             .HasMaxLength(36)
             .IsUnicode(false)
             .HasColumnName("FK_LIBRO_USUARIO");
            entity.Property(e => e.FechaPrestamo)
             .HasColumnType("date")
             .HasColumnName("FECHA_PRESTAMO");
            entity.Property(e => e.FechaDevolucion)
            .HasColumnType("date")
            .HasColumnName("FECHA_DEVOLUCION");
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
