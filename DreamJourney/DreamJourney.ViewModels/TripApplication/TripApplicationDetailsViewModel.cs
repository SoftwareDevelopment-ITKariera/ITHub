using DreamJourney.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJourney.ViewModels.TripApplication
{
    public class TripApplicationDetailsViewModel : BaseViewModel
    {
        public int UserId { get; set; }

        public string ImageUrl { get; set; }

        public string UserFirstLastName { get; set; }

        public string UserEmail { get; set; }

        public int TripId { get; set; }

        public ApplicationStatus Status { get; set; }
    }
}
