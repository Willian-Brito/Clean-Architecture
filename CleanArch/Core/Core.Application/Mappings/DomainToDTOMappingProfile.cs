using AutoMapper;
using Core.Application.DTOs.Categories;
using Core.Application.DTOs.Products;
using Core.Domain;
using Core.Domain.Entities;

namespace Core.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Category, CategoryCreateDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}
