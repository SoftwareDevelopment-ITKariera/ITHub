using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DreamJourney.ViewModels.User
{
    public class RegisterViewModel:BaseViewModel
    {
        [Required]
        [MaxLength(40)]
        [MinLength(3, ErrorMessage = "Minimum length of '3'")]
        public string Username { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(6, ErrorMessage = "Minimum length of '6'")]
        public string Password { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(3, ErrorMessage = "Minimum length of '3'")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(3, ErrorMessage = "Minimum length of '3'")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(3, ErrorMessage = "Minimum length of '3'")]
        public string Email { get; set; }

        [Required]
        public bool Role { get; set; }

        [DisplayName("Image URL")]
        public string ImageUrl { get; set; }
    }
}
