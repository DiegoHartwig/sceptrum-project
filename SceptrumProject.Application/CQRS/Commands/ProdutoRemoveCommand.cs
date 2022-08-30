using MediatR;
using SceptrumProject.Domain.Entities;

namespace SceptrumProject.Application.CQRS.Commands
{
    public class ProdutoRemoveCommand : IRequest<Produto>
    {
        public int Id { get; set; }
        public ProdutoRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
