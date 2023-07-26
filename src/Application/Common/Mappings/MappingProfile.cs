using AutoMapper;
using practice.Application.Handlers.Products.Commands;
using practice.Application.Handlers.Products.Queries;
using practice.Domain.Entities;

namespace practice.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductCommand, Product>();
        CreateMap<Product, CreateProductCommand>();
        CreateMap<Product, GetProductsQuery>().ReverseMap();
    }
}
