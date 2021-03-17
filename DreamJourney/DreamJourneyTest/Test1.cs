using DreamJourney.Data;
using DreamJourney.Data.Models;
using DreamJourney.Services;
using DreamJourney.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver.Core.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamJourneyTest
{
    public class Test1
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetByUsername_Return_Correct_User()
        {
            var data = new List<User>
            {
                new User(){ Id = 1, FirstName = "Misho", Username = "darabara"},
                new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"},
                 new User(){ Id = 3, FirstName = "Emcho", Username = "dara"},
            }.AsQueryable();

            //var mockSet = new Mock<DbSet<User>>();
            //mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            //mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            //mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            //mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            //var mockContext = new Mock<DreamJourneyDbContext>();
            //mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            //var mockService = new Mock<IBaseService<User>>();
            //mockService.Setup(x => x.GetAll()).Returns(data.ToList());

            //IUsersService usersService = new UsersService(mockService.Object);
            //var result = usersService.GetByUsername("darabarastochadura");

            //Assert.AreEqual("Aleksi", result.FirstName);
        }


        public void GetByUsername_Return_Correct_User1()
        {
            var data = new List<User>
            {
                new User(){ Id = 1, FirstName = "Misho", Username = "darabara"},
                new User(){ Id = 2, FirstName = "Aleksi", Username = "darabarastochadura"},
                 new User(){ Id = 3, FirstName = "Emcho", Username = "dara"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>(); mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider); mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression); mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType); mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DreamJourneyDbContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var expectedUser = data.ToList()[0];

            var service = new UsersService(mockContext.Object);
            var user = service.GetByUsername(expectedUser.Username);

            Assert.IsTrue(expectedUser.FirstName == user.FirstName 
                && expectedUser.ImageUrl == user.ImageUrl
                && expectedUser.Id == user.Id
                && expectedUser.LastName == user.LastName);

            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());


        }
    }
}
