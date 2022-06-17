using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TemplateCleanArch.Application.CQRS.Queries;
using TemplateCleanArch.Domain.Entities;
using TemplateCleanArch.Domain.Interfaces;

namespace TemplateCleanArch.Application.CQRS.Handlers
{
	public class BuscarProdutosPeloIdQueryHandler : IRequestHandler<BuscarProdutosPeloIdQuery, Produto>
	{
		private readonly IProdutoRepository _produtoRepository;

		public BuscarProdutosPeloIdQueryHandler(IProdutoRepository produtoRepository)
		{
			_produtoRepository = produtoRepository ??
				throw new ArgumentNullException(nameof(produtoRepository));
		}

		public async Task<Produto> Handle(BuscarProdutosPeloIdQuery request, CancellationToken cancellationToken)
		{
			return await _produtoRepository.BuscarPeloIdAsync(request.Id);
		}
	}
}
