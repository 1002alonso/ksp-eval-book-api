using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Domain.Entities
{
    public  class CbTabLibro
    {
        public Guid IdLibro { get; set; }
        public string Folio { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string? Autor { get; set; }
        public Guid? FkEditorial { get; set; }
        public int? Anio { get; set; }
        public int? NumCopias { get; set; }
        public DateTime? DtAlta { get; set; }
        public DateTime? DtActualiza { get; set; }
        public string? UsuarioAlta { get; set; }
    }
}
