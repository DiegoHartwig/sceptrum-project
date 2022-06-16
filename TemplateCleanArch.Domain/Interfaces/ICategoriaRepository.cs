using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateCleanArch.Domain.Entities;

namespace TemplateCleanArch.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categoria> CriarAsync(Categoria categoria);
        Task<Categoria> BuscarPeloIdAsync(int? id);
        Task<IEnumerable<Categoria>> BuscarCategoriasAsync();
        Task<Categoria> AtualizarAsync(Categoria categoria);
        Task<Categoria> RemoverAsync(Categoria categoria);
    }
}
