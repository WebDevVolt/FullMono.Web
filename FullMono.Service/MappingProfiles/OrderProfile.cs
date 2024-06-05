using AutoMapper;
using FullMono.Repository.Entities;
using FullMono.Shared.Dtos;

namespace FullMono.Service.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<OrderItemDto, OrderItem>().ReverseMap();
        }
    }
}
