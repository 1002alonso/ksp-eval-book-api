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
    class CbTabUsuarioConfig : IEntityTypeConfiguration<CbTabUsuario>
    {
        public void Configure(EntityTypeBuilder<CbTabUsuario> entity)
        {
            entity.ToTable("CB_TAB_USUARIO");
            entity.HasKey(c => c.IdUsuario);

            entity.Property(e => e.IdUsuario)
             .HasMaxLength(36)
             .IsUnicode(false)
             .HasColumnName("ID_USUARIO");
           entity.Property(e => e.NombreUsuario)
           .HasMaxLength(36)
           .IsUnicode(false)
           .HasColumnName("NOMBRE_USUARIO");
            entity.Property(e => e.PasswordHash)
          .HasMaxLength(250)
          .IsUnicode(false)
          .HasColumnName("PASSWORD_HASH");
            entity.Property(e => e.Email)
          .HasMaxLength(36)
          .IsUnicode(false)
          .HasColumnName("EMAIL");
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
