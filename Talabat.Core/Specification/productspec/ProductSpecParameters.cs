using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Specification.productspec
{

    public class ProductSpecParameters
    {

        private const int maxsize = 10;
        private int pagesize=5;
        
        public int PageSize 
        {
            get { return pagesize; }
            set { pagesize=value > maxsize ? maxsize :value; }
        }


     
       // public string? search {  get; set; }
        public int PageIndex { get; set; } = 1;


        private string? search;
        public string? Search
        {
            get { return search; }
            set { search = value?.ToLower(); }
        }
        public string? sort {  get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }


    }
}
