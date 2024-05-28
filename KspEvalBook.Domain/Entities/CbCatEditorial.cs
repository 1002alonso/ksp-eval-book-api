using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Domain.Entities
{
    public class CbCatEditorial
    {
        public Guid IdEditorial { get; set; }
        public string? Nombre { get; set; }
        public DateTime? DtAlta { get; set; }

        public DateTime? DtActualiza { get; set; }

        public string? UsuarioAlta { get; set; }

     /*   public CbCatEditorial(Guid id, string nombre, DateTime dtAlta,DateTime dtAtualiza, string usuarioAlta)
        {
            IdEditorial = id;
            Nombre = nombre;
            DtAlta = dtAlta;
            DtActualiza=dtAtualiza;
            UsuarioAlta = usuarioAlta;
        }*/

    }
}
