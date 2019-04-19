using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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
                reservation.Col);

            this.db.Reservations.Add(newReservation);
            await this.db.SaveChangesAsync();
        }
    }
}