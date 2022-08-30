using System.Collections.Generic;
using System.Threading.Tasks;
using SceptrumProject.Domain.Entities;

namespace SceptrumProject.Domain.Interfaces
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
