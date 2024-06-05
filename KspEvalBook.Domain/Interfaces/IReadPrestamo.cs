using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Domain.Interfaces
{
    public interface IReadPrestamo<TEntidad, TUserBookID, TBookID>
    {
        int CountBookUser(TUserBookID userBookId, TBookID bookId);
        int CountBooks(TUserBookID userBookId);

        List<TEntidad> ReadAll(TUserBookID userBookId);
    }
}
