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
    public class TripsService : BaseService<Trip>, ITripsService
    {
        public TripsService(DreamJourneyDbContext context) : base(context)
        {
        }

        public List<Trip> GetAllWithUser()
        {
            return dbSet.Include(t => t.User).ToList();
        }

        public Trip GetById(int id, int userId)
        {
            return GetAll().FirstOrDefault(t => t.Id == id && t.UserId == userId);
        }

        public Trip GetByIdWithUser(int id)
        {
            return GetAllWithUser().FirstOrDefault(t => t.Id == id);
        }
    }
}
