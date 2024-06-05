using KspEvalBook.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Application.Interfaces
{
    public interface ILibroPrestamoService<TEntidad, TEntidadID> : ICreate<TEntidad>, IUpdateV<TEntidadID, TEntidad>, IReadV<TEntidad, TEntidadID>, IValidarPrestamo<TEntidadID,TEntidad>
    {
    }
}
