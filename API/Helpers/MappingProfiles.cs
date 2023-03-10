//Using Automapper.extensions.microsoft.dependencyinjection to replace manual DTO object codes
using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                //To let automapper know some properties in Product class are having entity as its type
                .ForMember(d=>d.ProductBrand,option=>option.MapFrom(source=>source.ProductBrand.Name))
                .ForMember(d=>d.ProductType, option=>option.MapFrom(source=>source.ProductType.Name))

            //adding pictureUrl with api url
           .ForMember(d => d.PictureUrl, option => option.MapFrom<ProductUrlResolver>());

        }
    }
}
