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
    public class ProdutoUpdateCommandHandler : IRequestHandler<ProdutoUpdateCommand, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoUpdateCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ??
                throw new ArgumentNullException(nameof(produtoRepository));
        }

        public async Task<Produto> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.BuscarPeloIdAsync(request.Id);

            if (produto == null)
            {
                throw new ApplicationException($"Ocorreu um erro.");
            }
            else
            {
                produto.Update(
                    request.Descricao,
                    request.Nome,
                    request.Preco,
                    request.Estoque,
                    request.Imagem,
                    request.CategoriaId);

                return await _produtoRepository.AtualizarAsync(produto);
            }
        }
    }
}
