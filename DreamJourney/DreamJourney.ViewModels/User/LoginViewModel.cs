using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DreamJourney.ViewModels.User
{
    public class LoginViewModel:BaseViewModel
    {
        [Required]
        [MaxLength(40)]
        [MinLength(3, ErrorMessage = "Minimum length of '3'")]
        public string Username { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(6, ErrorMessage = "Minimum length of '6'")]
        public string Password { get; set; }
    }
}
