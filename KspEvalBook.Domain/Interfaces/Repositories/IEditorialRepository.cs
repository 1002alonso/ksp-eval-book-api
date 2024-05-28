using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Domain.Interfaces.Repositories
{
    public interface IEditorialRepository<TEntidad, TEntidadID>: ICreate<TEntidad>, IUpdate<TEntidad>, IDelete<TEntidadID>, IRead<TEntidad, TEntidadID>, ITransaction   
    {
    }
}
