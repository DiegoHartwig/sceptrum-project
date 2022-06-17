using AutoMapper;
using TemplateCleanArch.Application.CQRS.Commands;
using TemplateCleanArch.Application.DTO;

namespace TemplateCleanArch.Application.Mapeamentos
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
