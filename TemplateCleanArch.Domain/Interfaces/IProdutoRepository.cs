using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateCleanArch.Domain.Entities;

namespace TemplateCleanArch.Domain.Interfaces
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
