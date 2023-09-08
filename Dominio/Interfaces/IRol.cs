using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IRol: IGenericRepository<Rol>
    {
        Task<Rol> GetByIdAsync(string id);
    }
}