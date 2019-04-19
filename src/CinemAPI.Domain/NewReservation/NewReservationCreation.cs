using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservation;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationCreation : INewReservation
    {
        private readonly IReservationRepository reservationRepo;

        public NewReservationCreation(IReservationRepository reservationRepo)
        {
            this.reservationRepo = reservationRepo;
        }

        public async Task<NewReservationSummary> New(IReservationCreation reservation)
        {
            var newReservation = new Reservation(

               reservation.ProjectionStartDate,
               reservation.MovieName,
               reservation.CinemaName,
               reservation.RoomNumber,
               reservation.Row,
               reservation.Col,
               reservation.ProjectionId);

            await this.reservationRepo.Insert(newReservation);

            var result = new NewReservationSummary(true)
            {
                Reservation = newReservation
            };

            return result;
        }
    }
}