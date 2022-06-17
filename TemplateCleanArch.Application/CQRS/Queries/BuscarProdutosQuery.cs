using MediatR;
using System.Collections.Generic;
using TemplateCleanArch.Domain.Entities;

namespace TemplateCleanArch.Application.CQRS.Queries
{
	public class BuscarProdutosQuery : IRequest<IEnumerable<Produto>>
	{
	}
}
