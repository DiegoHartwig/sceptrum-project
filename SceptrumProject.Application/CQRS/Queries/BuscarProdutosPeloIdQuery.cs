using MediatR;
using SceptrumProject.Domain.Entities;

namespace SceptrumProject.Application.CQRS.Queries
{
    public class BuscarProdutosPeloIdQuery : IRequest<Produto>
    {
        public int Id { get; set; }
        public BuscarProdutosPeloIdQuery(int id)
        {
            Id = id;
        }
    }
}
