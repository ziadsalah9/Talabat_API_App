﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Talabat.Dtos
{
    public class LoginDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


    }
}
