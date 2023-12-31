
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

    public class UserRepository :GenericRepository<User>, IUser
    {
         protected readonly PruebaContext _context;
        
        public UserRepository(PruebaContext context) : base (context)
        {
            _context = context;
        }
        
       public override async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(p => p.Rols)
                .ToListAsync();
        }

        public override async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
            .Include(p => p.Rols)
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users
            .Include(p => p.Rols)
            .FirstOrDefaultAsync(p =>  p.Username.ToLower() == username.ToLower());
        }
    }
        
    
