using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Domain.Entities
{
    public class CbTabLibroUsuario
    {
        public Guid IdLibroUsuario { get; set; }
        public string ClaveUsuario { get; set; }
        public string Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public DateTime? DtAlta { get; set; }
        public DateTime? DtActualiza { get; set; }
        public string? UsuarioAlta { get; set; }

    }
}
