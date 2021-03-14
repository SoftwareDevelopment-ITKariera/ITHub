using DreamJourney.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJourney.Services.Contracts
{
    public interface IUsersService:IBaseService<User>
    {
        User GetByUsernameAndPassword(string username, string password);
        User GetByUsername(string username);
    }
}
