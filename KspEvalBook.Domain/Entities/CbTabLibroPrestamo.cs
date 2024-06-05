using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Domain.Entities
{
    public class CbTabLibroPrestamo
    {
        public Guid IdPrestamo { get; set; }
        public Guid FkLibro { get; set; }
        public Guid FkLibroUsuario { get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public DateTime? DtAlta { get; set; }
        public DateTime? DtActualiza { get; set; }
        public string? UsuarioAlta { get; set; }


    }
}
