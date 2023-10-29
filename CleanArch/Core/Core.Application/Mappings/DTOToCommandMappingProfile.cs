using AutoMapper;
using Core.Application.DTOs;
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
