using AutoMapper;
using PS.Produc.API.Models;

namespace PS.Produc.API.DTOs.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
