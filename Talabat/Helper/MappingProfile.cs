using AutoMapper;
using Talabat.Core.Models;
using Talabat.Dtos;

namespace Talabat.Helper
{
    public class MappingProfile :Profile
    {

        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDTO>().ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());


            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketitemDto,Basketitem>();
                
        }

    }
}
