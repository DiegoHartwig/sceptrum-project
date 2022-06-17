using MediatR;
using TemplateCleanArch.Domain.Entities;

namespace TemplateCleanArch.Application.CQRS.Commands
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
