using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Projection;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CinemAPI.Data.Implementation
{
    public class ProjectionRepository : IProjectionRepository
    {
        private readonly CinemaDbContext db;

        public ProjectionRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<IProjection> Get(int movieId, int roomId, DateTime startDate)
        {
            return await db.Projections.FirstOrDefaultAsync(x => x.MovieId == movieId &&
                                                      x.RoomId == roomId &&
                                                      x.StartDate == startDate);
        }

        public async Task<IEnumerable<IProjection>> GetActiveProjections(int roomId)
        {
            DateTime now = DateTime.UtcNow;

            return await db.Projections.Where(x => x.RoomId == roomId &&
                                             x.StartDate > now)
                                             .ToListAsync();
        }

        public async Task Insert(IProjectionCreation proj)
        {
            Projection newProj = new Projection(proj.MovieId, proj.RoomId, proj.StartDate, proj.AvailableSeatsCount);

            db.Projections.Add(newProj);
            await db.SaveChangesAsync();
        }
    }
}