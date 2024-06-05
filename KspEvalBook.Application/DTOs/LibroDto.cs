using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Application.DTOs
{
    public class LibroDto
    {
        public Guid? idLibro { get; set; }
        public string? folio { get; set; }
        public string? titulo { get; set; }
        public string? descripcion { get; set; }
        public string? autor { get; set; }
        public Guid? fkEditorial { get; set; }
        public int anio { get; set; }
        public int numCopias { get; set; }
        public DateTime? dtAlta { get; set; }
        public DateTime? dtActualiza { get; set; }
        public string? usuarioAlta { get; set; }
    }
}
