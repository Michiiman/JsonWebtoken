
using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IUser : IGenericRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
        
    }
}