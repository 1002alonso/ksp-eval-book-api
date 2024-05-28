using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Application.Interfaces
{
    public interface IReadV<TEntidad, TEntidadID>
    {
        List<TEntidad> ReadAll();

        TEntidad Read(TEntidadID entidadId);
    }
}
