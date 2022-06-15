using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateCleanArchMvc.Domain.Entities;

namespace TemplateCleanArchMvc.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> BuscarProdutosAsync();
        Task<Produto> BuscarPeloIdAsync(int? id);
        Task<Produto> BuscarPelaCategoriaAsync(int? id);
        Task<Produto> CriarAsync(Produto produto);
        Task<Produto> AtualizarAsync(Produto produto);
        Task<Produto> RemoverAsync(Produto produto);
    }
}
