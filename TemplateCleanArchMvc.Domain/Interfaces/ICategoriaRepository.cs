using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateCleanArchMvc.Domain.Entities;

namespace TemplateCleanArchMvc.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> BuscarCategoriasAsync();
        Task<Categoria> BuscarPeloIdAsync(int? id);
        Task<Categoria> CriarAsync(Categoria categoria);
        Task<Categoria> AtualizarAsync(Categoria categoria);
        Task<Categoria> RemoverAsync(Categoria categoria);
    }
}
