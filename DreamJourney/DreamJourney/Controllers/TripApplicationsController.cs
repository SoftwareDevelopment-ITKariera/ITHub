using DreamJourney.Data.Models;
using DreamJourney.Filters;
using DreamJourney.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJourney.Controllers
{
    public class TripApplicationsController:Controller
    {
        private readonly ITripApplicationsService tripApplicationService;
        private readonly ITripsService tripService;

        public TripApplicationsController(ITripApplicationsService tripApplicationService, ITripsService tripService)
        {
            this.tripApplicationService = tripApplicationService;
            this.tripService = tripService;
        }
        [TravellerFilter]
        public IActionResult Apply(int? tripId)
        {
            if (!tripId.HasValue)
            {
                return RedirectToAction("List", "Trips");
            }
            TripApplication tripApp = tripApplicationService.GetByTripIdUserId(tripId.Value, HttpContext.Session.GetInt32("loggedUserId").Value);
            if (tripApp == null)
            {
                TripApplication application = new TripApplication()
                {
                    UserId = HttpContext.Session.GetInt32("loggedUserId").Value,
                    TripId = tripId.Value,
                    Status = Data.Models.Enums.ApplicationStatus.Pending
                };
                tripApplicationService.Insert(application);
            }

            return RedirectToAction("Details", "Trips", new { id = tripId });
        }
        [TravellerFilter]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("List", "Trips");
            }
            TripApplication tripApp = tripApplicationService.GetById(id.Value);
            if (tripApp != null && tripApp.UserId == AuthUser.LoggedUser.Id)
            {
                tripApplicationService.Delete(tripApp.Id);
            }
            return RedirectToAction("Details", "Trips", new { id = tripApp.TripId });
        }

        public IActionResult Accept(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("List", "Trip");
            }
            TripApplication tripApp = tripApplicationService.GetById(id.Value);
            if (tripService.GetById(tripApp.TripId).UserId == HttpContext.Session.GetInt32("loggedUserId").Value)
            {
                if (Counters.AvailableSeats == 0)
                {
                    return RedirectToAction("Details", "Trips", new { id = tripApp.TripId });
                }
                tripApp.Status = Data.Models.Enums.ApplicationStatus.Accepted;
                tripApplicationService.Update(tripApp);
            }
            return RedirectToAction("Details", "Trips", new { id = tripApp.TripId });
        }

        public IActionResult Reject(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("List", "Trips");
            }
            TripApplication tripApp = tripApplicationService.GetById(id.Value);
            if (tripService.GetById(tripApp.TripId).UserId == HttpContext.Session.GetInt32("loggedUserId").Value)
            {
                tripApp.Status = Data.Models.Enums.ApplicationStatus.Rejected;
                tripApplicationService.Update(tripApp);
            }
            return RedirectToAction("Details", "Trips", new { id = tripApp.TripId });
        }
    }
}
