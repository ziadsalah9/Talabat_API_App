﻿using System.ComponentModel.DataAnnotations;

namespace Talabat.Dtos
{
    public class BasketitemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }

        [Required]

        public string PictureUrl { get; set; }

        [Required]
        [Range(0.1, double.MaxValue ,ErrorMessage =$"Price must be greater than zero !" )]
        public decimal Price { get; set; }

        public string Brand { get; set; }
        public string Category { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = $"Qunatity must be at least one item")]
        public int Quantity { get; set; }
    }
}