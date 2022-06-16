using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateCleanArch.Domain.Entities;

namespace TemplateCleanArch.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> CriarAsync(Produto produto);
        Task<Produto> BuscarPeloIdAsync(int? id);
        Task<IEnumerable<Produto>> BuscarProdutosAsync();
        Task<Produto> BuscarProdutoCategoriaAsync(int? id); 
        Task<Produto> AtualizarAsync(Produto produto);
        Task<Produto> RemoverAsync(Produto produto);
    }
}
