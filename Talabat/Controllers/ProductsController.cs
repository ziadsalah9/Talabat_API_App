using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.IRepositories;
using Talabat.Core.Models;
using Talabat.Core.Specification;
using Talabat.Core.Specification.productspec;
using Talabat.Dtos;
using Talabat.Error;
using Talabat.Helper;

namespace Talabat.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> productsRepo;
        private readonly IMapper mapper;
        private readonly IGenericRepository<ProductBrand> brandRepo;
        private readonly IGenericRepository<ProductCategory> categoryRepo;

        public ProductsController(IGenericRepository<Product> productsRepo , IMapper mapper , 
            
            IGenericRepository<ProductBrand> brandRepo , IGenericRepository<ProductCategory> categoryRepo
            
         )
        {
            this.productsRepo = productsRepo;
            this.mapper = mapper;
            this.brandRepo = brandRepo;
            this.categoryRepo = categoryRepo;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagination<ProductToReturnDTO>>>> GetAll([FromQuery]ProductSpecParameters productSpecParameters)
        {

            var spec = new ProductWithBrandAndCategorySpecification(productSpecParameters);
            var products = await productsRepo.GetAllWithSpecificationAsync(spec);
            var data = mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDTO>>(products);
           
            var Productspeccount =new ProductsWithFilterationCountSpecification(productSpecParameters);
            var count =await productsRepo.GetCountwithspec(Productspeccount);
            return Ok(new Pagination<ProductToReturnDTO>(productSpecParameters.PageIndex, productSpecParameters.PageSize, count, data));
        }




        [ProducesResponseType(typeof(ProductToReturnDTO), 200)]
        [ProducesResponseType(typeof(ApiResponse),404)]
        [HttpGet("id")]
        public async Task <ActionResult<ProductToReturnDTO>> Get( int id)
        { 
           var spec = new ProductWithBrandAndCategorySpecification(id);
            var product = await productsRepo.GetByIdWithSpecificationAsync(spec);
        
            if(product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(mapper.Map<Product,ProductToReturnDTO>(product));
        
        }


        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductBrands()
        {
            return Ok(await brandRepo.GetAllAsync());

        }


   


        [HttpGet("Categories")]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategories()
        {
            return Ok(await categoryRepo.GetAllAsync());

        }


    }
}
