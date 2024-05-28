using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Domain.Interfaces
{
    public interface IDelete<TEntidadID>
    {
        void Delete(TEntidadID entidadId);
    }
}
