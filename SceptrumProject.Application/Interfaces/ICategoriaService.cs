using System.Collections.Generic;
using System.Threading.Tasks;
using SceptrumProject.Application.DTO;

namespace SceptrumProject.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task CriarAsync(CategoriaDTO categoria);
        Task<CategoriaDTO> BuscarPeloIdAsync(int? id);
        Task<IEnumerable<CategoriaDTO>> BuscarCategoriasAsync();
        Task AtualizarAsync(CategoriaDTO categoria);
        Task RemoverAsync(int? id);
    }
}
