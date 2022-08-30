using AutoMapper;
using SceptrumProject.Application.DTO;
using SceptrumProject.Domain.Entities;

namespace SceptrumProject.Application.Mapeamentos
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
