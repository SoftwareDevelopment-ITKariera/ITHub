using DreamJourney.Data;
using DreamJourney.Data.Models;
using DreamJourney.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DreamJourney.Test.Service
{
    public class TripServiceTests
    {
        [Fact]
        public void GetAllWithUser_WorkWell()
        {
            var data = new List<Trip>
            {
                new Trip(){Id=1, Title = "title", Destinations="Paris", User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new Trip(){Id=2, Title = "title2", Destinations="Paris2" },
                new Trip(){Id=3, Title = "title3", Destinations="Paris3" }
            }.AsQueryable();

            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.Trips.AddRange(data);
            context.SaveChanges();

            var tripService = new TripsService(context);

            var expectedData = data.Where(x=>x.User!=null).ToList();
            var actualData = tripService.GetAllWithUser();


            Assert.Equal(1, actualData.Count);
            Assert.Equal<Trip>(expectedData, actualData);
        }
        [Fact]
        public void GetById_WorkWell()
        {
            var data = new List<Trip>
            {
                new Trip(){Id=1, Title = "title", Destinations="Paris", UserId = 1 },
                new Trip(){Id=2, Title = "title2", Destinations="Paris2",UserId = 2 },
                new Trip(){Id=3, Title = "title3", Destinations="Paris3",UserId = 3 }
            }.AsQueryable();

            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.Trips.AddRange(data);
            context.SaveChanges();

            var tripService = new TripsService(context);

            var expectedData = data.FirstOrDefault(x => x.Id ==1&&x.UserId==1);
            var actualData = tripService.GetById(1,1);


            Assert.Equal(expectedData, actualData);
        }
        [Fact]
        public void GetByIdWithUser_WorkWell()
        {
            var data = new List<Trip>
            {
                new Trip(){Id=1, Title = "title", Destinations="Paris",User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"}, UserId = 1 },
                new Trip(){Id=2, Title = "title2", Destinations="Paris2",UserId = 2 },
                new Trip(){Id=3, Title = "title3", Destinations="Paris3",UserId = 3 }
            }.AsQueryable();

            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.Trips.AddRange(data);
            context.SaveChanges();

            var tripService = new TripsService(context);

            var expectedData = data.FirstOrDefault(x => x.Id == 1 && x.User !=null);
            var actualData = tripService.GetByIdWithUser(1);

            var expectedData2 = data.FirstOrDefault(x => x.Id == 2 && x.User != null);
            var actualData2 = tripService.GetByIdWithUser(2); 

            Assert.Equal(expectedData, actualData);
            Assert.Equal(expectedData2, actualData2);
        }
    }
}
