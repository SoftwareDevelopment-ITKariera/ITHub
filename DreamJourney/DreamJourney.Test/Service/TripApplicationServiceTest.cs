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
    public class TripApplicationServiceTest
    {
        [Fact]
        public void GetByTripIdUserId_WorkWell()
        {
            var data = new List<TripApplication>
            {
                new TripApplication(){Id = 1, UserId=1, TripId=1 },
                new TripApplication(){Id = 2, UserId=2, TripId=2 },
                new TripApplication(){Id = 3, UserId=3, TripId=3 }
            }.AsQueryable();

            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.TripApplications.AddRange(data);
            context.SaveChanges();

            var userService = new TripApplicationsService(context);

            var expectedData = data.FirstOrDefault(x => x.UserId == 1 && x.TripId == 1);
            var actualData = userService.GetByTripIdUserId(1, 1);

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void GetByTripIdWithUser_WorkWell()
        {
            var data = new List<TripApplication>
            {
                new TripApplication(){Id = 1, UserId=1, TripId=1, User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new TripApplication(){Id = 2, UserId=2, TripId=2 },
                new TripApplication(){Id = 3, UserId=3, TripId=3 }
            }.AsQueryable();

            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.TripApplications.AddRange(data);
            context.SaveChanges();

            var userService = new TripApplicationsService(context);

            var expectedData = data.Where(x => x.TripId == 1 && x.User != null).ToList();
            var actualData = userService.GetByTripIdWithUser(1);

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void TripA_GetById_WorkWell()
        {
            var data = new List<TripApplication>
            {
                new TripApplication(){Id = 1, UserId=1, TripId=1, User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new TripApplication(){Id = 2, UserId=2, TripId=2 },
                new TripApplication(){Id = 3, UserId=3, TripId=3 }
            }.AsQueryable();

            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.TripApplications.AddRange(data);
            context.SaveChanges();

            var userService = new TripApplicationsService(context);

            var expectedData = data.FirstOrDefault(x => x.Id == 2);
            var actualData = userService.GetById(2);

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void TripA_GetAll_WorkWell()
        {
            var data = new List<TripApplication>
            {
                new TripApplication(){Id = 1, UserId=1, TripId=1, User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new TripApplication(){Id = 2, UserId=2, TripId=2 },
                new TripApplication(){Id = 3, UserId=3, TripId=3 }
            }.AsQueryable();

            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.TripApplications.AddRange(data);
            context.SaveChanges();

            var usersService = new TripApplicationsService(context);

            var expectedData = data.ToList();
            var actualData = usersService.GetAll();

            Assert.Equal<TripApplication>(expectedData, actualData);
        }
        [Fact]
        public void TripApplication_Delete_WorkWell()
        {
            var data = new List<TripApplication>
            {
                new TripApplication(){Id = 1, UserId=1, TripId=1, User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new TripApplication(){Id = 2, UserId=2, TripId=2 },
                new TripApplication(){Id = 3, UserId=3, TripId=3 }
            }.AsQueryable();

            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.TripApplications.AddRange(data);
            context.SaveChanges();

            var tripAService = new TripApplicationsService(context);
            var dbSet = context.Set<TripApplication>();

            var expected = dbSet.Count() - 1;
            tripAService.Delete(1);
            //var actualData = data.FirstOrDefault(x => x.Id == 1);
            //User expectedData = null;
            var actualCount = dbSet.Count();

            Assert.Equal(expected, actualCount);
        }
        [Fact]
        public void TripApplication_Insert_WorkWell()
        {
            var data = new List<TripApplication>
            {
                new TripApplication(){Id = 1, UserId=1, TripId=1, User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new TripApplication(){Id = 2, UserId=2, TripId=2 },
                new TripApplication(){Id = 3, UserId=3, TripId=3 }
            }.AsQueryable();

            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.TripApplications.AddRange(data);
            context.SaveChanges();

            var tripAService = new TripApplicationsService(context);
            var dbSet = context.Set<TripApplication>();

            var expected = dbSet.Count() + 1;
            tripAService.Insert(new TripApplication() { Id = 4, UserId = 4, TripId = 4 });
            //var actualData = data.FirstOrDefault(x => x.Id == 1);
            //User expectedData = null;
            var actualCount = dbSet.Count();

            Assert.Equal(expected, actualCount);
        }
        [Fact]
        public void Trip_Update_WorkWell()
        {
            var data = new List<TripApplication>
            {
                new TripApplication(){Id = 1, UserId=1, TripId=1, User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new TripApplication(){Id = 2, UserId=2, TripId=2 },
                new TripApplication(){Id = 3, UserId=3, TripId=3 }
            }.AsQueryable();

            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.TripApplications.AddRange(data);
            context.SaveChanges();

            var tripAService = new TripApplicationsService(context);
            var dbSet = context.Set<TripApplication>();

            TripApplication tripA = new TripApplication() { Id = 3, UserId = 3, TripId = 3 };
            tripAService.Update(tripA);

            var expected = 3;
            var actualData = dbSet.FirstOrDefault(x => x.Id == 3);

            Assert.Equal(expected, actualData.UserId);
        }
    }
}
