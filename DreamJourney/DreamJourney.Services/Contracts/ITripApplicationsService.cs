using DreamJourney.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJourney.Services.Contracts
{
    public interface ITripApplicationsService:IBaseService<TripApplication>
    {
        List<TripApplication> GetByTripIdWithUser(int tripId);
        TripApplication GetByTripIdUserId(int tripId, int userId);
    }
}
