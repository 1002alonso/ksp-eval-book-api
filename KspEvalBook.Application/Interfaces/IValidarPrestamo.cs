using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Application.Interfaces
{
    public interface IValidarPrestamo<TEntidadID,TEntidad>
    {
        int ValidarUsuarioLibro(TEntidad entidad);
        int ValidarLibro(TEntidad entidad);

        List<TEntidad> ReadAllIdUser(TEntidadID entidad);

    }
}
