using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TemplateCleanArch.Application.CQRS.Commands;
using TemplateCleanArch.Domain.Entities;
using TemplateCleanArch.Domain.Interfaces;

namespace TemplateCleanArch.Application.CQRS.Handlers
{
    public class ProdutoRemoveCommandHandler : IRequestHandler<ProdutoRemoveCommand, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoRemoveCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ??
                throw new ArgumentNullException(nameof(produtoRepository));
        }

        public async Task<Produto> Handle(ProdutoRemoveCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.BuscarPeloIdAsync(request.Id);

            if (produto == null)
            {
                throw new ApplicationException($"Ocorreu um erro.");
            }
            else
            {
                var resultado = await _produtoRepository.RemoverAsync(produto);
                return resultado;
            }
        }
    }
}
