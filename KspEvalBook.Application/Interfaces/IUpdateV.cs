using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Application.Interfaces
{
    public interface IUpdateV<TEntidadID,TEntidad>
    {
        void Update(TEntidadID entidadId, TEntidad entidad);
    }
}
