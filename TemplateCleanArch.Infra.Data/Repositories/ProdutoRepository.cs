using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateCleanArch.Domain.Entities;
using TemplateCleanArch.Domain.Interfaces;
using TemplateCleanArch.Infra.Data.DBContext;

namespace TemplateCleanArch.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> CriarAsync(Produto produto)
        {
            _context
                .Add(produto);

            await _context
                .SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> BuscarPeloIdAsync(int? id)
        {
            return await _context.Produtos
                .Include(c => c.Categoria)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> BuscarProdutosAsync()
        {
            return await _context.Produtos
                .ToListAsync();
        }

        public async Task<Produto> AtualizarAsync(Produto produto)
        {
            _context
                .Update(produto);

            await _context
                .SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> RemoverAsync(Produto produto)
        {
            _context
                .Remove(produto);

            await _context
                .SaveChangesAsync();

            return produto;
        }
    }
}
