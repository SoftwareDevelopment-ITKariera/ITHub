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
        public void GetByTripIdUserId_ShouldRetutnTripApplications_ByGivenTripIdAndUserId()
        {
            //data
            var data = new List<TripApplication>
            {
                new TripApplication(){Id = 1, UserId=1, TripId=1 },
                new TripApplication(){Id = 2, UserId=2, TripId=2 },
                new TripApplication(){Id = 3, UserId=3, TripId=3 }
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //context and service
            var context = new DreamJourneyDbContext(options);
            context.TripApplications.AddRange(data);
            context.SaveChanges();
            var tripApplicationsService = new TripApplicationsService(context);

            //Test
            var expectedData = data.FirstOrDefault(x => x.UserId == 1 && x.TripId == 1);
            var actualData = tripApplicationsService.GetByTripIdUserId(1, 1);
            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void GetByTripIdWithUser_ShouldReturnTripApplications_ByGivenTripId_ThatHaveUser()
        {
            //data
            var data = new List<TripApplication>
            {
                new TripApplication(){Id = 1, UserId=1, TripId=1, User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new TripApplication(){Id = 2, UserId=2, TripId=2 },
                new TripApplication(){Id = 3, UserId=3, TripId=3 }
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //context and service
            var context = new DreamJourneyDbContext(options);
            context.TripApplications.AddRange(data);
            context.SaveChanges();
            var tripApplicationsService = new TripApplicationsService(context);

            //Test
            var expectedData = data.Where(x => x.TripId == 1 && x.User != null).ToList();
            var actualData = tripApplicationsService.GetByTripIdWithUser(1);
            Assert.Equal(expectedData, actualData);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void TripApplication_GetById_ShouldReturnTripApplication_ByGivenId(int givenId)
        {
            //data
            var data = new List<TripApplication>
            {
                new TripApplication(){Id = 1, UserId=1, TripId=1, User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new TripApplication(){Id = 2, UserId=2, TripId=2 },
                new TripApplication(){Id = 3, UserId=3, TripId=3 }
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            //context and service
            var context = new DreamJourneyDbContext(options);
            context.TripApplications.AddRange(data);
            context.SaveChanges();
            var tripApplicationsService = new TripApplicationsService(context);
            
            //Test
            var expectedData = data.FirstOrDefault(x => x.Id == givenId);
            var actualData = tripApplicationsService.GetById(givenId);
            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void TripApplication_GetAll_ShouldReturnAllTripApplications()
        {
            //data
            var data = new List<TripApplication>
            {
                new TripApplication(){Id = 1, UserId=1, TripId=1, User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new TripApplication(){Id = 2, UserId=2, TripId=2 },
                new TripApplication(){Id = 3, UserId=3, TripId=3 }
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //context and service
            var context = new DreamJourneyDbContext(options);
            context.TripApplications.AddRange(data);
            context.SaveChanges();
            var tripApplicationsService = new TripApplicationsService(context);

            //Test
            var expectedData = data.ToList();
            var actualData = tripApplicationsService.GetAll();
            Assert.Equal<TripApplication>(expectedData, actualData);
        }

        [Fact]
        public void TripApplication_Delete_ShouldDeleteTripApplication_ByGivenId()
        {
            //data
            var data = new List<TripApplication>
            {
                new TripApplication(){Id = 1, UserId=1, TripId=1, User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new TripApplication(){Id = 2, UserId=2, TripId=2 },
                new TripApplication(){Id = 3, UserId=3, TripId=3 }
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //contex, service and dbset
            var context = new DreamJourneyDbContext(options);
            context.TripApplications.AddRange(data);
            context.SaveChanges();
            var tripApplicationsService = new TripApplicationsService(context);
            var dbSet = context.Set<TripApplication>();

            //Test
            var expected = dbSet.Count() - 1;
            tripApplicationsService.Delete(1);
            var actualCount = dbSet.Count();
            Assert.Equal(expected, actualCount);
        }

        [Fact]
        public void TripApplication_Insert_WorkWell()
        {
            //data
            var data = new List<TripApplication>
            {
                new TripApplication(){Id = 1, UserId=1, TripId=1, User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new TripApplication(){Id = 2, UserId=2, TripId=2 },
                new TripApplication(){Id = 3, UserId=3, TripId=3 }
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //contex, service and dbset
            var context = new DreamJourneyDbContext(options);
            context.TripApplications.AddRange(data);
            context.SaveChanges();
            var tripApplicationsService = new TripApplicationsService(context);
            var dbSet = context.Set<TripApplication>();

            //Test
            var expected = dbSet.Count() + 1;
            tripApplicationsService.Insert(new TripApplication() { Id = 4, UserId = 4, TripId = 4 });
            var actualCount = dbSet.Count();
            Assert.Equal(expected, actualCount);
        }

        [Fact]
        public void Trip_Update_WorkWell()
        {
            //data
            var data = new List<TripApplication>
            {
                new TripApplication(){Id = 1, UserId=1, TripId=1, User = new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"} },
                new TripApplication(){Id = 2, UserId=2, TripId=2 },
                new TripApplication(){Id = 3, UserId=3, TripId=3 }
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //contex, service and dbset
            var context = new DreamJourneyDbContext(options);
            context.TripApplications.AddRange(data);
            context.SaveChanges();
            var tripApplicationsService = new TripApplicationsService(context);
            var dbSet = context.Set<TripApplication>();

            //Test
            TripApplication tripA = new TripApplication() { Id = 3, UserId = 3, TripId = 3 };
            tripApplicationsService.Update(tripA);
            var expected = 3;
            var actualData = dbSet.FirstOrDefault(x => x.Id == 3);
            Assert.Equal(expected, actualData.UserId);
        }
    }
}
