// Projeto: Sceptrum Project
// Autor: Diego Hartwig
namespace SceptrumProject.Application.CQRS.Commands
{
	public class ProdutoUpdateCommand : ProdutoCommand
	{
		public int Id { get; set; }
	}
}
