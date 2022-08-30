using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SceptrumProject.Application.CQRS.Queries;
using SceptrumProject.Domain.Entities;
using SceptrumProject.Domain.Interfaces;

namespace SceptrumProject.Application.CQRS.Handlers
{
	public class BuscarProdutosQueryHandler : IRequestHandler<BuscarProdutosQuery, IEnumerable<Produto>>
	{
		private readonly IProdutoRepository _produtoRepository;

		public BuscarProdutosQueryHandler(IProdutoRepository produtoRepository)
		{
			_produtoRepository = produtoRepository ??
				throw new ArgumentNullException(nameof(produtoRepository));
		}

		public async Task<IEnumerable<Produto>> Handle(BuscarProdutosQuery request, CancellationToken cancellationToken)
		{
			return await _produtoRepository.BuscarProdutosAsync();
		}
	}
}
