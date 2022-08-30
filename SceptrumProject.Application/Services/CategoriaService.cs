using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using SceptrumProject.Application.DTO;
using SceptrumProject.Application.Interfaces;
using SceptrumProject.Domain.Entities;
using SceptrumProject.Domain.Interfaces;

namespace SceptrumProject.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository _repository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CriarAsync(CategoriaDTO categoriaDto)
        {
            var categoriaEntidade = _mapper.Map<Categoria>(categoriaDto);
            await _repository.CriarAsync(categoriaEntidade);
        }

        public async Task<CategoriaDTO> BuscarPeloIdAsync(int? id)
        {
            var categoria = await _repository.BuscarPeloIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task<IEnumerable<CategoriaDTO>> BuscarCategoriasAsync()
        {
            var categorias = await _repository.BuscarCategoriasAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
        }

        public async Task AtualizarAsync(CategoriaDTO categoriaDto)
        {
            var categoriaEntidade = _mapper.Map<Categoria>(categoriaDto);
            await _repository.AtualizarAsync(categoriaEntidade);
        }

        public async Task RemoverAsync(int? id)
        {
            var categoriaEntidade = await _repository.BuscarPeloIdAsync(id);
            await _repository.RemoverAsync(categoriaEntidade);

        }
    }
}
