using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Ventas.Shared.Entidades;
using Ventas.Shared.Responses;
using VentasBackend.Data;
using VentasBackend.Repositories.Interfaces;

namespace VentasBackend.Repositories.Implementation
{
    public class CategoriasRepository : GenericRepository<Categoria>, ICategoriasRepository
    {
        private readonly DataContext _context;
        public CategoriasRepository(DataContext context):base(context) 
        {
            _context = context;
        }
       
        public override async Task<ActionResponse<IEnumerable<Categoria>>> GetAsync()
        {
            var categorias = await _context.Categorias.Include(c=>c.Tiendas).ToListAsync();
            return new ActionResponse<IEnumerable<Categoria>>
            {
                WasSuccess = true,
                Result = categorias
            };  
        }

        public override async Task<ActionResponse<Categoria>> GetAsync(int id)
        {
            var categoria = await _context.Categorias
                 .Include(c => c.Tiendas)
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null)
            {
                return new ActionResponse<Categoria>
                {
                    WasSuccess = false,
                    Message = "País no existe"
                };
            }

            return new ActionResponse<Categoria>
            {
                WasSuccess = true,
                Result = categoria
            };
        }
    

}
}
