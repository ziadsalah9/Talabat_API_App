using System.ComponentModel.DataAnnotations;
using Talabat.Core.Models;

namespace Talabat.Dtos
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; }

        public List<BasketitemDto> Items { get; set; }



    }
}
