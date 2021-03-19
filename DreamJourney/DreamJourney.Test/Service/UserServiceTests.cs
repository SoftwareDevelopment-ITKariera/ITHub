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
        public void GetByUsername_ShouldReturnTheRightUser_ByGivenUsername()
        {
            //data
            var data = new List<User>
            {
                new User(){ Id = 1, FirstName = "Misho", Username = "darabara"},
                new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"},
                 new User(){ Id = 3, FirstName = "Emcho", Username = "dara"},
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //context and service
            var context = new DreamJourneyDbContext(options);
            context.Users.AddRange(data);
            context.SaveChanges();
            var userService = new UsersService(context);

            //FirstTest
            var expectedData = data;
            var actualData = userService.GetByUsername("dara");
            var result = expectedData.FirstOrDefault(x => x.Username == "dara").FirstName;
            Assert.Equal(result, actualData.FirstName);

            //SecondTest
            User expectedData1 = null;
            var actualData1 = userService.GetByUsername("123");
            Assert.Equal(expectedData1, actualData1);
        }

        [Fact]
        public void GetByUsernameAndPassword_ShouldReturnTheRightUser_ByGivenUsernameAndPassword()
        {
            //data
            var data = new List<User>
            {
                new User(){ Id = 1, FirstName = "Misho", Username = "darabara", Password="123"},
                new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura", Password="1234"},
                 new User(){ Id = 3, FirstName = "Emcho", Username = "dara", Password="1235"},
            }.AsQueryable();

            //oprions
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //context and service
            var context = new DreamJourneyDbContext(options);
            context.Users.AddRange(data);
            context.SaveChanges();
            var userService = new UsersService(context);

            //FirstTest
            var expectedData = data;
            var actualData = userService.GetByUsernameAndPassword("dara", "1235");
            var result = expectedData.FirstOrDefault(x => x.Username == "dara");
            Assert.True(result.FirstName == actualData.FirstName && result.Password == actualData.Password);

            //SecondTest
            User expectedData1 = null;
            var actualData1 = userService.GetByUsernameAndPassword("dara1", "1235");
            Assert.Equal(expectedData1, actualData1);

            //ThirdTest
            User expectedData2 = null;
            var actualData2 = userService.GetByUsernameAndPassword("dara", "12345");
            Assert.Equal(expectedData2, actualData2);

            //FourthTest
            User expectedData3 = null;
            var actualData3 = userService.GetByUsernameAndPassword("dara1", "12345");
            Assert.Equal(expectedData3, actualData3);

        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void GetById_ShouldReturnTheRightUser_ByGivenId(int givenId)
        {
            //data
            var data = new List<User>
            {
            new User(){ Id = 1, FirstName = "Misho", Username = "darabara"},
            new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"},
            new User(){ Id = 3, FirstName = "Emcho", Username = "dara"},
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            //context and service
            var context = new DreamJourneyDbContext(options);
            context.Users.AddRange(data);
            context.SaveChanges();
            var userService = new UsersService(context);

            //Test
            var expectedData = data.FirstOrDefault(x => x.Id == givenId);
            var actualData = userService.GetById(givenId);
            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void GetAll_ShouldReturnAllUsers()
        {
            //data
            var data = new List<User>
            {
                new User(){ Id = 1, FirstName = "Misho", Username = "darabara"},
                new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"},
                 new User(){ Id = 3, FirstName = "Emcho", Username = "dara"},
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //context and service
            var context = new DreamJourneyDbContext(options);
            context.Users.AddRange(data);
            context.SaveChanges();
            var usersService = new UsersService(context);

            //Test
            var expectedData = data.ToList();
            var actualData = usersService.GetAll();
            Assert.Equal<User>(expectedData, actualData);
        }

        [Fact]
        public void Delete_ShouldDeleteUser_ByGivenId()
        {
            //data
            var data = new List<User>
            {
                new User(){ Id = 1, FirstName = "Misho", Username = "darabara"},
                new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"},
                 new User(){ Id = 3, FirstName = "Emcho", Username = "dara"},
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //context, service and dbset
            var context = new DreamJourneyDbContext(options);
            context.Users.AddRange(data);
            context.SaveChanges();
            var usersService = new UsersService(context);
            var dbSet = context.Set<User>();

            //Test
            var expected = dbSet.Count() - 1;
            usersService.Delete(1);
            var actualCount = dbSet.Count();
            Assert.Equal(expected, actualCount);
        }

        [Fact]
        public void Insert_ShouldInsertGivenUser()
        {
            //data
            var data = new List<User>
            {
                new User(){ Id = 1, FirstName = "Misho", Username = "darabara"},
                new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"},
                 new User(){ Id = 3, FirstName = "Emcho", Username = "dara"},
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //context, service and dbset
            var context = new DreamJourneyDbContext(options);
            context.Users.AddRange(data);
            context.SaveChanges();
            var usersService = new UsersService(context);
            var dbSet = context.Set<User>();

            //Test
            var expected = dbSet.Count() + 1;
            usersService.Insert(new User() { Id = 4, FirstName = "Emi", Username = "dara1" });
            var actualCount = dbSet.Count();
            Assert.Equal(expected, actualCount);
        }

        [Fact]
        public void Update_ShouldUpdateGivenUser()
        {
            //data
            var data = new List<User>
            {
                new User(){ Id = 1, FirstName = "Misho", Username = "darabara"},
                new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"},
                 new User(){ Id = 3, FirstName = "Emcho", Username = "dara"},
            }.AsQueryable();

            //options
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //context, service and dbset
            var context = new DreamJourneyDbContext(options);
            context.Users.AddRange(data);
            context.SaveChanges();
            var usersService = new UsersService(context);
            var dbSet = context.Set<User>();

            //Test
            User user = new User() { Id = 3, FirstName = "Emi", Username = "dara1" };
            usersService.Update(user);
            var expected = "Emi";
            var actualData = dbSet.FirstOrDefault(x => x.Id == 3);
            Assert.Equal(expected, actualData.FirstName);
        }
    }
}
