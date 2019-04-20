using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Ticket;
using System.Threading.Tasks;

namespace CinemAPI.Domain.BuyTicketWithReservation
{
    public class BuyTicketWithReservationValidation : IBuyWithReservation
    {
        private readonly IReservationRepository reservationRepo;
        private readonly IBuyWithReservation buyWithoutReservation;

        public BuyTicketWithReservationValidation(IReservationRepository reservationRepo, IBuyWithReservation buyWithoutReservation)
        {
            this.reservationRepo = reservationRepo;
            this.buyWithoutReservation = buyWithoutReservation;
        }

        public async Task<TicketSummary> Buy(IReservation reservation)
        {
            var reservationMade = await this.reservationRepo.GetByKey(reservation.Id);

            if (reservationMade == null)
            {
                return new TicketSummary(false, "Can't buy ticket without reservation");
            }

            reservation.Id = reservationMade.Id;
            reservation.MovieName = reservationMade.MovieName;
            reservation.ProjectionStartDate = reservationMade.ProjectionStartDate;
            reservation.CinemaName = reservationMade.CinemaName;
            reservation.Row = reservationMade.Row;
            reservation.Col = reservationMade.Col;
            reservation.RoomNumber = reservationMade.RoomNumber;
            reservation.ProjectionId = reservationMade.ProjectionId;

            return await this.buyWithoutReservation.Buy(reservation);
        }
    }
}