using KspEvalBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Infrastructure.Configurations
{
    class CbTabLibroUsuarioConfig : IEntityTypeConfiguration<CbTabLibroUsuario>
    {
        public void Configure(EntityTypeBuilder<CbTabLibroUsuario> entity)
        {
            entity.ToTable("CB_TAB_LIBRO_USUARIO");
            entity.HasKey(c => c.IdLibroUsuario);

            entity.Property(e => e.IdLibroUsuario)
               .HasMaxLength(36)
               .IsUnicode(false)
               .HasColumnName("ID_LIBRO_USUARIO");
            entity.Property(e => e.ClaveUsuario)
            .HasMaxLength(12)
            .IsUnicode(false)
            .HasColumnName("CLAVE_USUARIO");
            entity.Property(e => e.Nombre)
              .HasMaxLength(250)
              .IsUnicode(false)
              .HasColumnName("NOMBRE");
            entity.Property(e => e.Direccion)
              .HasMaxLength(250)
              .IsUnicode(false)
              .HasColumnName("DIRECCION");
            entity.Property(e => e.Telefono)
              .HasMaxLength(10)
              .IsUnicode(false)
              .HasColumnName("TELEFONO");
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
