using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Domain.Interfaces.Repositories
{
    public  interface IPrestamoLibroRepository <TEntidad,TUserBookID, TBookID> : ICreate<TEntidad>, IUpdate<TEntidad>, IReadPrestamo<TEntidad,TUserBookID, TBookID>, IRead<TEntidad, TUserBookID>
    {
    }
}
