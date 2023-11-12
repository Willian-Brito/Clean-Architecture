using AutoMapper;
using Core.Application.DTOs.Products;
using Core.Application.Products.Commands;

namespace Core.Application;

public class DTOToCommandMappingProfile : Profile
{
    public DTOToCommandMappingProfile()
    {
        CreateMap<ProductDTO, ProductCreateCommand>();
        CreateMap<ProductDTO, ProductUpdateCommand>();
    }
}
