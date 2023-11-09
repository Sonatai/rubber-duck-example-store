using API.CoreModels;
using API.DTOs;
using AutoMapper;

namespace API.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<CartRequestDto, Cart>();
            CreateMap<Cart, CartResponseDto>();

            CreateMap<SelectedProduct, SelectedProductDto>();
            CreateMap<SelectedProductDto, SelectedProduct>();
        }
    }
}
