using AutoMapper;
using TemplateCleanArch.Application.DTO;
using TemplateCleanArch.Domain.Entities;

namespace TemplateCleanArch.Application.Mapeamentos
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Categoria, CategoriaDTO>()
                .ReverseMap();

            CreateMap<Produto, ProdutoDTO>()
                .ReverseMap();
        }
    }
}
