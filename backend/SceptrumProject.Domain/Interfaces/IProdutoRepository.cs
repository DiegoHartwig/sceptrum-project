// Projeto: Sceptrum Project
// Autor: Diego Hartwig
using System.Collections.Generic;
using System.Threading.Tasks;
using SceptrumProject.Domain.Entities;

namespace SceptrumProject.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> CriarAsync(Produto produto);
        Task<Produto> BuscarPeloIdAsync(int? id);
        Task<IEnumerable<Produto>> BuscarProdutosAsync(); 
        Task<Produto> AtualizarAsync(Produto produto);
        Task<Produto> RemoverAsync(Produto produto);
    }
}
