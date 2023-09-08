using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

    public class RolRepository : GenericRepository<Rol> , IRol
    {
        protected readonly PruebaContext _context;
        
        public RolRepository(PruebaContext context) : base (context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Rol>> GetAllAsync()
        {
            return await _context.Rols
                .Include(p => p.Users)
                .ToListAsync();
        }

        public override async Task<Rol> GetByIdAsync(int id)
        {
            return await _context.Rols
                .Include(p => p.Users)
                .FirstOrDefaultAsync(p =>  p.Id == id);
        }
    }
