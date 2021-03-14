using DreamJourney.Data;
using DreamJourney.Data.Models;
using DreamJourney.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamJourney.Services
{
    public class TripApplicationsService:BaseService<TripApplication>, ITripApplicationsService
    {
        public TripApplicationsService(DreamJourneyDbContext context) : base(context)
        {
        }

        public TripApplication GetByTripIdUserId(int tripId, int userId)
        {
            return GetAll().FirstOrDefault(ta => ta.TripId == tripId && ta.UserId == userId);
        }

        public List<TripApplication> GetByTripIdWithUser(int tripId)
        {
            return dbSet.Include(ta => ta.User).Where(ta => ta.TripId == tripId).ToList();
        }
    }
}
