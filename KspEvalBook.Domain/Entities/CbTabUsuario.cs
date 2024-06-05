using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Domain.Entities
{
    public class CbTabUsuario
    {
        public Guid IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime? DtAlta { get; set; }
        public DateTime? DtActualiza { get; set; }
        public string? UsuarioAlta { get; set; }

    }
}
