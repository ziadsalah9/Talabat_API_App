using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;

namespace Talabat.Core.Specification.productspec
{
    public class ProductsWithFilterationCountSpecification : BaseSpecification<Product>
    {

        public ProductsWithFilterationCountSpecification(ProductSpecParameters productSpecParameters): base(

            p =>


                (string.IsNullOrEmpty(productSpecParameters.Search) || p.Name.ToLower().Contains(productSpecParameters.Search)) &&
                (!productSpecParameters.BrandId.HasValue||p.BrandId==productSpecParameters.BrandId.Value)&&
                (!productSpecParameters.CategoryId.HasValue||p.CategoryId==productSpecParameters.CategoryId.Value)
           
            )



        {
            
        }

    }
}
