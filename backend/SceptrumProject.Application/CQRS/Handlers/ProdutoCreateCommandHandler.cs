// Projeto: Sceptrum Project
// Autor: Diego Hartwig
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using SceptrumProject.Application.CQRS.Commands;
using SceptrumProject.Domain.Entities;
using SceptrumProject.Domain.Interfaces;

namespace SceptrumProject.Application.CQRS.Handlers
{
    public class ProdutoCreateCommandHandler : IRequestHandler<ProdutoCreateCommand, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoCreateCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto(
                request.Descricao,
                request.Nome,
                request.Preco,
                request.Estoque,
                request.Imagem);

            if(produto == null)
			{
                throw new ApplicationException($"Ocorreu um erro.");
			}
            else
			{
                produto.CategoriaId = request.CategoriaId;
                return await _produtoRepository.CriarAsync(produto);
			}
        }
    }
}
