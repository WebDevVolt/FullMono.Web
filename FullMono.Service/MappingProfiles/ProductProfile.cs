using AutoMapper;
using FullMono.Repository.Entities;
using FullMono.Shared.Dtos;

namespace FullMono.Service.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
