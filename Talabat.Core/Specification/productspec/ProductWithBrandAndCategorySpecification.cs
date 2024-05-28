using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;

namespace Talabat.Core.Specification.productspec
{
    public class ProductWithBrandAndCategorySpecification : BaseSpecification<Product>
    {

        public ProductWithBrandAndCategorySpecification(ProductSpecParameters productSpecParameters) :base(
            
            p=>  
            
                
                 (string.IsNullOrEmpty(productSpecParameters.Search)|| p.Name.ToLower().Contains(productSpecParameters.Search)   )&&
                 (!productSpecParameters.BrandId.HasValue||p.BrandId==productSpecParameters.BrandId)&&
                 (!productSpecParameters.CategoryId.HasValue||p.CategoryId==productSpecParameters.CategoryId)
            
            )
        {
            Includes.Add(p=>p.Brand);
            Includes.Add(p=>p.Category);
            if (!string.IsNullOrEmpty(productSpecParameters.sort))
            {
                switch (productSpecParameters.sort)
                {
                    case "PriceAsc":
                        OrderBy = p => p.Price;
                        break;
                    case "PriceDesc":
                        OrderByDesc = p => p.Price;
                        break;
                    default:
                        OrderBy = p => p.Name;
                        break;


                }
            }
            else
            {
                OrderBy = p => p.Name;
            }

            //no.of product : 18 
            //pagesize : 5 
            //page index : 2

            ApplyPagination((productSpecParameters.PageIndex - 1)*productSpecParameters.PageSize, productSpecParameters.PageSize);

        }


        public ProductWithBrandAndCategorySpecification(int id) : base(p=>p.Id==id)
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);

        }

        


    }
}
