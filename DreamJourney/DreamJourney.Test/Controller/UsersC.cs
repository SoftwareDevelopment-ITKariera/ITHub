using DreamJourney.Controllers;
using DreamJourney.Data;
using DreamJourney.Services;
using DreamJourney.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DreamJourney.Test.Controller
{
    public class UsersC
    {
        [Fact]
        public void TestUsersLoginView()
        {
            var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DreamJourneyDbContext(options);
            context.SaveChanges();

            var userService = new UsersService(context);
            var loginVM = new LoginViewModel();
            var controller = new UsersController(userService);
            var result = controller.Login(loginVM) as ViewResult;
            Assert.Equal(loginVM, result.Model);
        }
    }
}
