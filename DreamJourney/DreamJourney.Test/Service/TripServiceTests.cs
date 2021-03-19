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
        public void GetAllWithUser_ShouldReturnAllTrips_ThatHaveUser()
        {
            //data
            var data = new List<Trip>
            {
                new Trip(){Id=1, Title = "title", Destinations="Paris", User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new Trip(){Id=2, Title = "title2", Destinations="Paris2" },
                new Trip(){Id=3, Title = "title3", Destinations="Paris3" }
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //contex and service
            var context = new DreamJourneyDbContext(options);
            context.Trips.AddRange(data);
            context.SaveChanges();
            var tripService = new TripsService(context);

            //Test
            var expectedData = data.Where(x=>x.User!=null).ToList();
            var actualData = tripService.GetAllWithUser();
            Assert.Equal<Trip>(expectedData, actualData);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void GetById_ShouldReturnTrip_ByGivenId(int givenId)
        {
            //data
            var data = new List<Trip>
            {
            new Trip(){Id=1, Title = "title", Destinations="Paris", UserId = 1 },
            new Trip(){Id=2, Title = "title2", Destinations="Paris2",UserId = 2 },
            new Trip(){Id=3, Title = "title3", Destinations="Paris3",UserId = 3 }
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            //context and service
            var context = new DreamJourneyDbContext(options);
            context.Trips.AddRange(data);
            context.SaveChanges();
            var tripService = new TripsService(context);

            //Test
            var expectedData = data.FirstOrDefault(x => x.Id == givenId && x.UserId == givenId);
            var actualData = tripService.GetById(givenId, givenId);
            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void GetByIdWithUser_ShouldReturnTrip_ByGivenId_ThatHaveUser()
        {
            //data
            var data = new List<Trip>
            {
                new Trip(){Id=1, Title = "title", Destinations="Paris",User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"}, UserId = 1 },
                new Trip(){Id=2, Title = "title2", Destinations="Paris2",UserId = 2 },
                new Trip(){Id=3, Title = "title3", Destinations="Paris3",UserId = 3 }
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //context and service
            var context = new DreamJourneyDbContext(options);
            context.Trips.AddRange(data);
            context.SaveChanges();
            var tripService = new TripsService(context);

            //FirstTest
            var expectedData = data.FirstOrDefault(x => x.Id == 1 && x.User !=null);
            var actualData = tripService.GetByIdWithUser(1);
            Assert.Equal(expectedData, actualData);

            //SecondTest
            var expectedData2 = data.FirstOrDefault(x => x.Id == 2 && x.User != null);
            var actualData2 = tripService.GetByIdWithUser(2);             
            Assert.Equal(expectedData2, actualData2);
        }

        [Fact]
        public void Trip_GetById_ShouldReturnTrip_ByGivenId()
        {
            //data
            var data = new List<Trip>
            {
                new Trip(){Id=1, Title = "title", Destinations="Paris",User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"}, UserId = 1 },
                new Trip(){Id=2, Title = "title2", Destinations="Paris2",UserId = 2 },
                new Trip(){Id=3, Title = "title3", Destinations="Paris3",UserId = 3 }
            }.AsQueryable();
            
            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //context and service
            var context = new DreamJourneyDbContext(options);
            context.Trips.AddRange(data);
            context.SaveChanges();
            var tripService = new TripsService(context);

            //Test
            var expectedData = data.FirstOrDefault(x => x.Id == 2);
            var actualData = tripService.GetById(2);
            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void Trip_GetAll_ShouldReturnAllTrips()
        {
            //data
            var data = new List<Trip>
            {
                new Trip(){Id=1, Title = "title", Destinations="Paris", User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new Trip(){Id=2, Title = "title2", Destinations="Paris2" },
                new Trip(){Id=3, Title = "title3", Destinations="Paris3" }
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //context and service
            var context = new DreamJourneyDbContext(options);
            context.Trips.AddRange(data);
            context.SaveChanges();
            var tripService = new TripsService(context);

            //Test
            var expectedData = data.ToList();
            var actualData = tripService.GetAll();
            Assert.Equal<Trip>(expectedData, actualData);
        }
        [Fact]
        public void Trip_Delete_ShouldDeleteTrip_ByGivenId()
        {
            //data
            var data = new List<Trip>
            {
                new Trip(){Id=1, Title = "title", Destinations="Paris", User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new Trip(){Id=2, Title = "title2", Destinations="Paris2" },
                new Trip(){Id=3, Title = "title3", Destinations="Paris3" }
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //contex, service and dbset
            var context = new DreamJourneyDbContext(options);
            context.Trips.AddRange(data);
            context.SaveChanges();
            var tripsService = new TripsService(context);
            var dbSet = context.Set<Trip>();

            //Test
            var expected = dbSet.Count() - 1;
            tripsService.Delete(1);
            var actualCount = dbSet.Count();
            Assert.Equal(expected, actualCount);
        }

        [Fact]
        public void Trip_Insert_ShouldInsertGivenTrip()
        {
            //data
            var data = new List<Trip>
            {
                new Trip(){Id=1, Title = "title", Destinations="Paris", User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new Trip(){Id=2, Title = "title2", Destinations="Paris2" },
                new Trip(){Id=3, Title = "title3", Destinations="Paris3" }
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //context, service and dbset
            var context = new DreamJourneyDbContext(options);
            context.Trips.AddRange(data);
            context.SaveChanges();
            var tripsService = new TripsService(context);
            var dbSet = context.Set<Trip>();

            //Test
            var expected = dbSet.Count() + 1;
            tripsService.Insert(new Trip() { Id = 4, Title = "title4", Destinations = "Paris4" });
            var actualCount = dbSet.Count();
            Assert.Equal(expected, actualCount);
        }

        [Fact]
        public void Trip_Update_WorkWell()
        {
            //data
            var data = new List<Trip>
            {
                new Trip(){Id=1, Title = "title", Destinations="Paris", User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new Trip(){Id=2, Title = "title2", Destinations="Paris2" },
                new Trip(){Id = 3, Title = "title3", Destinations="Paris3" }
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //context, service, dbset
            var context = new DreamJourneyDbContext(options);
            context.Trips.AddRange(data);
            context.SaveChanges();
            var tripsService = new TripsService(context);
            var dbSet = context.Set<Trip>();
                                 
            //Test
            Trip trip = new Trip() { Id = 3, Title = "title33", Destinations = "Paris33" };
            tripsService.Update(trip);
            var expected = "title33";
            var actualData = dbSet.FirstOrDefault(x => x.Id == 3);
            Assert.Equal(expected, actualData.Title);
        }

    }
}
