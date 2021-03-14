using DreamJourney.Data;
using DreamJourney.Data.Models;
using DreamJourney.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DreamJourney.Services
{
    public class UsersService : BaseService<User>, IUsersService
    {
        public UsersService(DreamJourneyDbContext context) : base(context)
        {

        }
        public User GetByUsername(string username)
        {
            return GetAll().FirstOrDefault(user => user.Username == username);
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return GetAll().FirstOrDefault(user => user.Username == username && user.Password == password);
        }
    }
}
