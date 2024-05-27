using KspEvalBook.Domain.Interfaces;

namespace KspEvalBook.Application.Interfaces
{
     public interface IGenericService<TEntidad, TEntidadID> : ICreate<TEntidad>, IUpdateV<TEntidadID,TEntidad>, IDelete<TEntidadID>, IReadV<TEntidad, TEntidadID>
    {
    }
}
