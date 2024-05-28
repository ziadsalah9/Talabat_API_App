using AutoMapper;
using Talabat.Core.Models;
using Talabat.Dtos;

namespace Talabat.Helper
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductToReturnDTO, string>
    {
        private readonly IConfiguration configuration;

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {

            if (!string.IsNullOrEmpty(source.PictureUrl))

                return $"{configuration["ApiBaseUrl"]}/{source.PictureUrl}";

            else return string.Empty;

        }
    }
}
