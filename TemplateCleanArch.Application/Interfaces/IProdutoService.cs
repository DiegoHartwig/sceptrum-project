using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateCleanArch.Application.DTO;

namespace TemplateCleanArch.Application.Interfaces
{
    public interface IProdutoService
    {
        Task CriarAsync(ProdutoDTO produtoDto);
        Task AtualizarAsync(ProdutoDTO produtoDto);
        Task RemoverAsync(int? id);
        Task<ProdutoDTO> BuscarPeloIdAsync(int? id);
        Task<IEnumerable<ProdutoDTO>> BuscarProdutosAsync();
        Task<ProdutoDTO> BuscarProdutoCategoriaAsync(int? id);
    }
}
