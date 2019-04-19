using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CinemAPI.Data.Implementation
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CinemaDbContext db;

        public ReservationRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<IReservation> GetByKey(int key)
        {
            return await this.db.Reservations.FirstOrDefaultAsync(r => r.Id == key);
        }

        public async Task<IReservation> GetByProjectionId(int projectionId)
        {
            return await this.db.Reservations.FirstOrDefaultAsync(p => p.ProjectionId == projectionId);
        }

        public async Task<IEnumerable<IReservation>> GetByProjectionTime(DateTime before)
        {
            return await this.db.Reservations
                .Where(r => r.ProjectionStartDate >= before)
                .ToListAsync();
        }

        public async Task<IReservation> GetSpecificReservation(
            DateTime projectionStartDate,
            string movieName,
            string cinemaName,
            int roomNumber,
            int row,
            int col)
        {
            return await this.db.Reservations
                .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber &&
                    r.ProjectionStartDate == projectionStartDate &&
                    r.MovieName == movieName &&
                    r.CinemaName == cinemaName &&
                    r.Col == col &&
                    r.Row == row);
        }

        public async Task Insert(IReservationCreation reservation)
        {
            Reservation newReservation = new Reservation(
                reservation.ProjectionStartDate,
                reservation.MovieName,
                reservation.CinemaName,
                reservation.RoomNumber,
                reservation.Row,
                reservation.Col,
                reservation.ProjectionId);

            this.db.Reservations.Add(newReservation);
            await this.db.SaveChangesAsync();
        }
    }
}