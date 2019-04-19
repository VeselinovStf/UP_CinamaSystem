using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewReservation
{
    /// <summary>
    /// Task
    /// </summary>
    public class NewReservationReservedSeatValidation : INewReservation
    {
        private readonly IReservationRepository reservationRepository;
        private readonly INewReservation newReservation;

        public NewReservationReservedSeatValidation(IReservationRepository reservationRepository, INewReservation newReservation)
        {
            this.reservationRepository = reservationRepository;
            this.newReservation = newReservation;
        }

        public async Task<NewReservationSummary> New(IReservationCreation reservation)
        {
            var madeReservation = await this.reservationRepository
                .GetSpecificReservation(
                reservation.ProjectionStartDate,
                reservation.MovieName,
                reservation.CinemaName,
                reservation.RoomNumber,
                reservation.Row, reservation.Col
                );

            if (madeReservation == null)
            {
                return await this.newReservation.New(reservation);
            }

            return new NewReservationSummary(false, "Already reserved seats");
        }
    }
}