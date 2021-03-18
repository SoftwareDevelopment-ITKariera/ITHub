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
    public class UserServiceTests
    {
        [Fact]
        public void GetByUsername_WorkWell()
        {            
            var data = new List<User>
            {
                new User(){ Id = 1, FirstName = "Misho", Username = "darabara"},
                new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"},
                 new User(){ Id = 3, FirstName = "Emcho", Username = "dara"},
            }.AsQueryable();

            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.Users.AddRange(data);
            context.SaveChanges();

            var userService = new UsersService(context);

            var expectedData = data;
            var actualData = userService.GetByUsername("dara");

            var result = expectedData.FirstOrDefault(x => x.Username == "dara").FirstName;

            Assert.Equal(result, actualData.FirstName);
        }
        [Fact]
        public void GetByUsernameAndPassword_WorkWell()
        {
            var data = new List<User>
            {
                new User(){ Id = 1, FirstName = "Misho", Username = "darabara", Password="123"},
                new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura", Password="1234"},
                 new User(){ Id = 3, FirstName = "Emcho", Username = "dara", Password="1235"},
            }.AsQueryable();

            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.Users.AddRange(data);
            context.SaveChanges();

            var userService = new UsersService(context);

            var expectedData = data;
            var actualData = userService.GetByUsername("dara");

            var result = expectedData.FirstOrDefault(x => x.Username == "dara");

            Assert.True(result.FirstName== actualData.FirstName&& result.Password == actualData.Password);
        }

        [Fact]
        public void GetById_WorkWell()
        {
            var data = new List<User>
            {
                new User(){ Id = 1, FirstName = "Misho", Username = "darabara"},
                new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"},
                 new User(){ Id = 3, FirstName = "Emcho", Username = "dara"},
            }.AsQueryable();

            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.Users.AddRange(data);
            context.SaveChanges();

            var userService = new UsersService(context);

            var expectedData = data.FirstOrDefault(x => x.Id == 2);
            var actualData = userService.GetById(2);

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void User_GetAll_WorkWell()
        {
            var data = new List<User>
            {
                new User(){ Id = 1, FirstName = "Misho", Username = "darabara"},
                new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"},
                 new User(){ Id = 3, FirstName = "Emcho", Username = "dara"},
            }.AsQueryable();

            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.Users.AddRange(data);
            context.SaveChanges();

            var usersService = new UsersService(context);

            var expectedData = data.ToList();
            var actualData = usersService.GetAll();

            Assert.Equal<User>(expectedData, actualData);
        }

        [Fact]
        public void User_Delete_WorkWell()
        {
            var data = new List<User>
            {
                new User(){ Id = 1, FirstName = "Misho", Username = "darabara"},
                new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"},
                 new User(){ Id = 3, FirstName = "Emcho", Username = "dara"},
            }.AsQueryable();

            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.Users.AddRange(data);
            context.SaveChanges();
            
            var usersService = new UsersService(context);
            var dbSet  = context.Set<User>();

            var expected = dbSet.Count() - 1;
            usersService.Delete(1);
            //var actualData = data.FirstOrDefault(x => x.Id == 1);
            //User expectedData = null;
            var actualCount = dbSet.Count();

            Assert.Equal(expected, actualCount);
        }

    }
}
