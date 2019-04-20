using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Reservation;
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

        //TODO:

        public async Task UpdateSingleAvailibleSeat(int value, long projectionId)
        {
            var dbModel = await this.db.Projections.FirstOrDefaultAsync(p => p.Id == projectionId);

            dbModel.AvailableSeatsCount += value;

            await this.db.SaveChangesAsync();
        }

        public async Task<IProjection> Get(long projectionId)
        {
            return await this.db.Projections.FirstOrDefaultAsync(p => p.Id == projectionId);
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

        public async Task UpdateAvailibleSeats(int value, IEnumerable<IReservation> reservations)
        {
            foreach (var item in reservations)
            {
                var dbModel = await this.db.Projections.FirstOrDefaultAsync(p => p.Id == item.ProjectionId);

                dbModel.AvailableSeatsCount += value;
            }

            await db.SaveChangesAsync();
        }
    }
}