// Projeto: Sceptrum Project
// Autor: Diego Hartwig
using MediatR;
using SceptrumProject.Domain.Entities;

namespace SceptrumProject.Application.CQRS.Commands
{
	public abstract class ProdutoCommand : IRequest<Produto>
	{
        public string Descricao { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public string Imagem { get; private set; }
		public int CategoriaId { get; set; }
	}
}
