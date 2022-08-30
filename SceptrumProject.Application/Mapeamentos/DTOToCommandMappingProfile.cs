using AutoMapper;
using SceptrumProject.Application.CQRS.Commands;
using SceptrumProject.Application.DTO;

namespace SceptrumProject.Application.Mapeamentos
{
	public class DTOToCommandMappingProfile : Profile
	{
		public DTOToCommandMappingProfile()
		{
			CreateMap<ProdutoDTO, ProdutoCreateCommand>();
			CreateMap<ProdutoDTO, ProdutoUpdateCommand>();
		}
	}
}
