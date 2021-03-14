using DreamJourney.Data.Models;
using DreamJourney.Filters;
using DreamJourney.Services.Contracts;
using DreamJourney.ViewModels.Trip;
using DreamJourney.ViewModels.TripApplication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJourney.Controllers
{
    public class TripsController:Controller
    {
        private readonly ITripsService tripService;
        private readonly ITripApplicationsService tripApplicationsService;

        public TripsController(ITripsService tripService, ITripApplicationsService tripApplicationsService)
        {
            this.tripService = tripService;
            this.tripApplicationsService = tripApplicationsService;
        }


        public IActionResult List()
        {
            List<TripListViewModel> modelList = tripService.GetAllWithUser().Select(t => new TripListViewModel()
            {
                Id = t.Id,
                Title = t.Title,
                Date = t.Date,
                Days = t.Days,
                Destinations = t.Destinations,
                ImageUrl = t.ImageUrl,
                Price = t.Price,
                UserId = t.UserId,
                UserFirstLastNames = t.User.FirstName + " " + t.User.LastName

            }).ToList();
            return View(modelList);
        }

        [UserFilter]
        public IActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Trip trip = tripService.GetByIdWithUser(id.Value);
                if (trip != null)
                {
                    TripDetailsViewModel model = new TripDetailsViewModel()
                    {
                        Id = trip.Id,
                        Title = trip.Title,
                        Date = trip.Date,
                        Days = trip.Days,
                        Destinations = trip.Destinations,
                        ImageUrl = trip.ImageUrl,
                        UserId = trip.UserId,
                        FromPlace = trip.FromPlace,
                        Seats = trip.Seats,
                        Description = trip.Description,
                        Price = trip.Price,
                        UserFirstLastName = trip.User.FirstName + " " + trip.User.LastName

                    };
                    List<TripApplication> tripApplications = new List<TripApplication>();

                    tripApplications = tripApplicationsService.GetByTripIdWithUser(model.Id);

                    List<TripApplicationDetailsViewModel> appModel = tripApplications.Select(ta => new TripApplicationDetailsViewModel()
                    {
                        Id = ta.Id,
                        UserId = ta.UserId,
                        TripId = ta.TripId,
                        UserEmail = ta.User.Email,
                        UserFirstLastName = ta.User.FirstName + " " + ta.User.LastName,
                        ImageUrl = ta.User.ImageUrl,
                        Status = ta.Status
                    }).ToList();
                    model.TripApplications = appModel;
                    Counters.AvailableSeats = model.Seats - appModel.Where(ta => ta.Status == Data.Models.Enums.ApplicationStatus.Accepted).Count();
                    model.AvailableSeats = Counters.AvailableSeats;
                    return View(model);
                }
            }
            return RedirectToAction("List");
        }

        [UserFilter]
        [TripCreatorFilter]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                //Create
                TripEditViewModel model = new TripEditViewModel();
                return View(model);
            }
            else
            {
                //Edit
                Trip trip = tripService.GetById(id.Value, HttpContext.Session.GetInt32("loggedUserId").Value);
                if (trip == null)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    TripEditViewModel model = new TripEditViewModel()
                    {
                        Id = trip.Id,
                        Title = trip.Title,
                        Date = trip.Date,
                        Days = trip.Days,
                        Destinations = trip.Destinations,
                        ImageUrl = trip.ImageUrl,
                        UserId = trip.UserId,
                        FromPlace = trip.FromPlace,
                        Seats = trip.Seats,
                        Description = trip.Description,
                        Price = trip.Price
                    };
                    return View(model);
                }
            }
        }

        [HttpPost]
        [UserFilter]
        [TripCreatorFilter]
        public IActionResult Edit(TripEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Date < DateTime.Now)
            {
                ModelState.AddModelError("Date Error", "The deparature date must be in the future!");
                return View(model);
            }
            Trip tripCheck = tripService.GetById(model.Id, HttpContext.Session.GetInt32("loggedUserId").Value);
            Trip trip = new Trip()
            {
                Id = model.Id,
                Title = model.Title,
                Date = model.Date,
                Days = model.Days,
                Destinations = model.Destinations,
                ImageUrl = model.ImageUrl,
                UserId = HttpContext.Session.GetInt32("loggedUserId").Value,
                FromPlace = model.FromPlace,
                Seats = model.Seats,
                Description = model.Description,
                Price = model.Price
            };
            if (tripCheck == null)
            {
                tripService.Insert(trip);
            }
            else
            {
                tripService.Update(trip);
            }
            return RedirectToAction("List");
        }

        [UserFilter]
        [TripCreatorFilter]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("List");
            }
            Trip trip = tripService.GetById(id.Value, HttpContext.Session.GetInt32("loggedUserId").Value);
            if (trip == null)
            {
                return RedirectToAction("List");
            }
            tripService.Delete(trip.Id);
            return RedirectToAction("List");
        }
    }
}
