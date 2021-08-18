﻿using System.ComponentModel.DataAnnotations;

namespace MatrixHeroes.Models.Dtos.Requests
{
    public class UserRegistrationDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
