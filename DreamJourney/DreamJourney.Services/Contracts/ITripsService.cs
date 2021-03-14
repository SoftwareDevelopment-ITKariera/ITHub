using DreamJourney.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJourney.Services.Contracts
{
    public interface ITripsService:IBaseService<Trip>
    {
        List<Trip> GetAllWithUser();
        Trip GetById(int id, int userId);
        Trip GetByIdWithUser(int id);
    }
}
