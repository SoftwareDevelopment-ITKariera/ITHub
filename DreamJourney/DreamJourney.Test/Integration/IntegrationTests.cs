using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DreamJourney.Test.Integration
{
    public class IntegrationTests
    {
        [Fact]
        public async Task IndexPageIsOK()
        {
            var service = new WebApplicationFactory<Startup>();
            var client = service.CreateClient();
            var response = await client.GetAsync("/Home/Index");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PrivacyPageIsOK()
        {
            var service = new WebApplicationFactory<Startup>();
            var client = service.CreateClient();
            var response = await client.GetAsync("/Home/Privacy");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TripDetailsIsOK()
        {
            var service = new WebApplicationFactory<Startup>();
            var client = service.CreateClient();
            var response = await client.GetAsync("/Trips/Details");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TripEditIsOK()
        {
            var service = new WebApplicationFactory<Startup>();
            var client = service.CreateClient();
            var response = await client.GetAsync("/Trips/Edit");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TripListIsOK()
        {
            var service = new WebApplicationFactory<Startup>();
            var client = service.CreateClient();
            var response = await client.GetAsync("/Trips/List");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        //[Fact]
        //public async Task TripApplicationDetailsIsOK()
        //{
        //    var service = new WebApplicationFactory<Startup>();
        //    var client = service.CreateClient();
        //    var response = await client.GetAsync("/Views/TripApplications/Details");
        //    var html = await response.Content.ReadAsStringAsync();
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //}

        [Fact]
        public async Task UsersLoginIsOK()
        {
            var service = new WebApplicationFactory<Startup>();
            var client = service.CreateClient();
            var response = await client.GetAsync("/Users/Login");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UsersLoginIsOK_Comtains()
        {
            var service = new WebApplicationFactory<Startup>();
            var client = service.CreateClient();
            var response = await client.GetAsync("/Users/Login");
            var html = await response.Content.ReadAsStringAsync();
            Assert.Contains("</div>", html);
        }

        [Fact]
        public async Task UsersRegisterIsOK()
        {
            var service = new WebApplicationFactory<Startup>();
            var client = service.CreateClient();
            var response = await client.GetAsync("/Users/Register");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
