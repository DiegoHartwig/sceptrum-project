using MediatR;
using System.Collections.Generic;
using SceptrumProject.Domain.Entities;

namespace SceptrumProject.Application.CQRS.Queries
{
	public class BuscarProdutosQuery : IRequest<IEnumerable<Produto>>
	{
	}
}
