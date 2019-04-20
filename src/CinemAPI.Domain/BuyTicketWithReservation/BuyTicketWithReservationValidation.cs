using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
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

        public async Task<TicketSummary> Buy(ITicketCreate ticket)
        {
            var reservation = await this.reservationRepo.GetByKey(ticket.Id);

            if (reservation == null)
            {
                return new TicketSummary(false, "Can't buy ticket without reservation");
            }

            ticket.Id = reservation.Id;
            ticket.MovieName = reservation.MovieName;
            ticket.ProjectionStartDate = reservation.ProjectionStartDate;
            ticket.CinemaName = reservation.CinemaName;
            ticket.Row = reservation.Row;
            ticket.Col = reservation.Col;
            ticket.RoomNumber = reservation.RoomNumber;
            ticket.ProjectionId = reservation.ProjectionId;

            return await this.buyWithoutReservation.Buy(ticket);
        }
    }
}