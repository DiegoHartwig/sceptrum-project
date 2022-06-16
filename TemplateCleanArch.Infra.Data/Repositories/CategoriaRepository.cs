using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateCleanArch.Domain.Entities;
using TemplateCleanArch.Domain.Interfaces;
using TemplateCleanArch.Infra.Data.DBContext;

namespace TemplateCleanArch.Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> CriarAsync(Categoria categoria)
        {
            _context
                .Add(categoria);

            await _context
                .SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria> BuscarPeloIdAsync(int? id)
        {
            return await _context.Categorias
                .FindAsync(id);
        }

        public async Task<IEnumerable<Categoria>> BuscarCategoriasAsync()
        {
            return await _context.Categorias
                .ToListAsync();
        }

        public async Task<Categoria> AtualizarAsync(Categoria categoria)
        {
            _context
                .Update(categoria);

            await _context
                .SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria> RemoverAsync(Categoria categoria)
        {
            _context
                .Remove(categoria);

            await _context
                .SaveChangesAsync();

            return categoria;
        }
    }
}
