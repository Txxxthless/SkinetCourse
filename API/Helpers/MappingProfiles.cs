using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDTO>()
                .ForMember(
                    product => product.ProductBrand,
                    options => options.MapFrom(source => source.ProductBrand.Name)
                )
                .ForMember(
                    product => product.ProductType,
                    options => options.MapFrom(source => source.ProductType.Name)
                )
                .ForMember(
                    product => product.PictureUrl,
                    options => options.MapFrom<ProductUrlResolver>()
                );
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<CustomerBasketDTO, CustomerBasket>();
            CreateMap<BasketItemDTO, BasketItem>();
        }
    }
}
