using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Application.DTOs
{
    public class LibroUsuarioDto
    {
        public Guid idLibroUsuario { get; set; }
        public string claveUsuario { get; set; }
        public string nombre { get; set; }
        public string? direccion { get; set; }
        public string? telefono { get; set; }
        public DateTime? dtAlta { get; set; }
        public DateTime? dtActualiza { get; set; }
        public string? usuarioAlta { get; set; }
    }
}
