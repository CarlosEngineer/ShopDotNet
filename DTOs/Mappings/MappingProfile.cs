using AutoMapper;
using ShoppingNet.API.Models;

namespace ShoppingNet.API.DTOs.Mappings;

public class MappingProfile: Profile    
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}
