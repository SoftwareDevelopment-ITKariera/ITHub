using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DreamJourney.Data.Models
{
    public class User : BaseModel
    {
        public User()
        {
            this.Trips = new List<Trip>();
            this.TripApplications = new List<TripApplication>();
        }

        //[Required]
        //[Key]
        //public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Username { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(40)]
        public string Email { get; set; }

        [Required]
        public bool Role { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Trip> Trips { get; set; }

        public ICollection<TripApplication> TripApplications { get; set; }
    }
}
