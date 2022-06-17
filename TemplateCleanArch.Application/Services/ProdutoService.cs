using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateCleanArch.Application.CQRS.Commands;
using TemplateCleanArch.Application.CQRS.Queries;
using TemplateCleanArch.Application.DTO;
using TemplateCleanArch.Application.Interfaces;

namespace TemplateCleanArch.Application.Services
{
	public class ProdutoService : IProdutoService
	{
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public ProdutoService(IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_mediator = mediator;
		}

		public async Task CriarAsync(ProdutoDTO produtoDto)
		{
			var produtoCreateCommand = _mapper.Map<ProdutoCreateCommand>(produtoDto);
			await _mediator.Send(produtoCreateCommand);
		}

		public async Task RemoverAsync(int? id)
		{
			var produtoRemoveCommand = new ProdutoRemoveCommand(id.Value);

			if (produtoRemoveCommand == null)
				throw new Exception("Ocorreu um erro.");

			await _mediator.Send(produtoRemoveCommand);
		}

		public async Task AtualizarAsync(ProdutoDTO produtoDto)
		{
			var produtoUpdateCommand = _mapper.Map<ProdutoUpdateCommand>(produtoDto);
			await _mediator.Send(produtoUpdateCommand);
		}

		public async Task<ProdutoDTO> BuscarPeloIdAsync(int? id)
		{
			var produtosPorIdQuery = new BuscarProdutosPeloIdQuery(id.Value);

			if (produtosPorIdQuery == null)
				throw new Exception("Ocorreu um erro.");

			var resultado = await _mediator.Send(produtosPorIdQuery);

			return _mapper.Map<ProdutoDTO>(resultado);
		}		

		public async Task<IEnumerable<ProdutoDTO>> BuscarProdutosAsync()
		{
			var produtosQuery = new BuscarProdutosQuery();

			if (produtosQuery == null)
				throw new Exception("Ocorreu um erro.");

			var resultado = await _mediator.Send(produtosQuery);

			return _mapper.Map<IEnumerable<ProdutoDTO>>(resultado);
		}

	}
}
