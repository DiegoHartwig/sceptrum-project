using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TemplateCleanArch.Application.CQRS.Commands;
using TemplateCleanArch.Domain.Entities;
using TemplateCleanArch.Domain.Interfaces;

namespace TemplateCleanArch.Application.CQRS.Handlers
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
