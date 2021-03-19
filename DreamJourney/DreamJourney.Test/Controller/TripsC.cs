using DreamJourney.Controllers;
using DreamJourney.Data;
using DreamJourney.Services;
using DreamJourney.ViewModels;
using DreamJourney.ViewModels.Trip;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DreamJourney.Test.Controller
{
    public class TripsC
    {
        [Fact]
        public void TestTripsListView()
        {
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.SaveChanges();

            var tripService = new TripsService(context);
            var loginVM = new TripListViewModel();

            var tripAService = new TripApplicationsService(context);

            var controller = new TripsController(tripService, tripAService);
            var result = controller.List() as ViewResult;
            var expected = new List<TripListViewModel>();
            Assert.Equal(expected, result.Model);
        }

        [Fact]
        public void TestTripsEditView()
        {
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.SaveChanges();

            var tripService = new TripsService(context);
            var loginVM = new TripEditViewModel();

            var tripAService = new TripApplicationsService(context);
            var controller = new TripsController(tripService, tripAService);

            var result = controller.Edit(loginVM) as ViewResult;
            Assert.Equal(loginVM, result.Model);
        }
    }
}
