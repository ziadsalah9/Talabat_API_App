using System.ComponentModel.DataAnnotations.Schema;
using Talabat.Core.Models;

namespace Talabat.Dtos
{
    public class ProductToReturnDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }

        public decimal Price { get; set; }


        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        public string Brand { get; set; }  //navigtional property for relationship


        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public string Category { get; set; }


    }
}
