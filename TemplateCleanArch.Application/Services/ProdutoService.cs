using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateCleanArch.Application.DTO;
using TemplateCleanArch.Application.Interfaces;
using TemplateCleanArch.Domain.Entities;
using TemplateCleanArch.Domain.Interfaces;

namespace TemplateCleanArch.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));

            _mapper = mapper;
        }

        public async Task CriarAsync(ProdutoDTO produtoDto)
        {
            var produtoEntidade = _mapper.Map<Produto>(produtoDto);
            await _repository.CriarAsync(produtoEntidade);
        }

        public async Task RemoverAsync(int? id)
        {
            var produtoEntidade = await _repository.BuscarPeloIdAsync(id);
            await _repository.RemoverAsync(produtoEntidade);
        }

        public async Task AtualizarAsync(ProdutoDTO produtoDto)
        {
            var produtoEntidade = _mapper.Map<Produto>(produtoDto);
            await _repository.AtualizarAsync(produtoEntidade);
        }

        public async Task<ProdutoDTO> BuscarPeloIdAsync(int? id)
        {
            var produtoEntidade = await _repository.BuscarPeloIdAsync(id);
            return _mapper.Map<ProdutoDTO>(produtoEntidade);
        }

        public async Task<ProdutoDTO> BuscarProdutoCategoriaAsync(int? id)
        {
            var produtoEntidade = await _repository.BuscarProdutoCategoriaAsync(id);
            return _mapper.Map<ProdutoDTO>(produtoEntidade);
        }

        public async Task<IEnumerable<ProdutoDTO>> BuscarProdutosAsync()
        {
            var produtos = await _repository.BuscarProdutosAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

    }
}
