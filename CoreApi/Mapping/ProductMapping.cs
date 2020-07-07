using AutoMapper;
using CoreApi.Domain;
using CoreApi.Resources;

namespace CoreApi.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductResource, Product>();

            CreateMap<Product, ProductResource>();
        }
    }
}