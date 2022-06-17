using MediatR;
using TemplateCleanArch.Domain.Entities;

namespace TemplateCleanArch.Application.CQRS.Queries
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
