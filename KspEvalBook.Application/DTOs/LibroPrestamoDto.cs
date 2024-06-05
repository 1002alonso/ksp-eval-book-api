using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Application.DTOs
{
    public class LibroPrestamoDto
    {
        public Guid? idPrestamo { get; set; }
        public Guid fkLibro { get; set; }
        public Guid fkLibroUsuario { get; set; }
        public DateTime? fechaPrestamo { get; set; }
        public DateTime? fechaDevolucion { get; set; }
        public DateTime? dtAlta { get; set; }
        public DateTime? dtActualiza { get; set; }
        public string? usuarioAlta { get; set; }
        public string? tituloLibro { get; set; }
    }
}
