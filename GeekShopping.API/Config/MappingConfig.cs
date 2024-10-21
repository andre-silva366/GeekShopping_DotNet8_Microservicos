using AutoMapper;
using GeekShopping.ProductAPI.Model;
using GeekShoppingProduct.API.Data.ValueObjects;

namespace GeekShoppingProduct.API.Config;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductVO, Product>().ReverseMap();
        });
        return mappingConfig;
    }
}
