using DreamJourney.ViewModels.TripApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DreamJourney.ViewModels.Trip
{
    public class TripDetailsViewModel : BaseViewModel
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public int Days { get; set; }

        public string Destinations { get; set; }

        public double Price { get; set; }

        [DisplayName("From")]
        public string FromPlace { get; set; }

        public int Seats { get; set; }
        public int AvailableSeats { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        [DisplayName("Organised By")]
        public string UserFirstLastName { get; set; }

        public List<TripApplicationDetailsViewModel> TripApplications { get; set; }
    }
}
