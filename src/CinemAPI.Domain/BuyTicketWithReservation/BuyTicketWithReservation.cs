using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Ticket;
using System.Threading.Tasks;

namespace CinemAPI.Domain.BuyTicketWithReservation
{
    public class BuyTicketWithReservation : IBuyWithReservation
    {
        private readonly IReservationRepository reservationRepo;
        private readonly ITicketRepository ticketRepository;

        public BuyTicketWithReservation(IReservationRepository reservationRepo, ITicketRepository ticketRepository)
        {
            this.reservationRepo = reservationRepo;
            this.ticketRepository = ticketRepository;
        }

        public async Task<TicketSummary> Buy(IReservation reservation)
        {
            ITicketCreate ticket = new Ticket()
            {
                MovieName = reservation.MovieName,
                ProjectionStartDate = reservation.ProjectionStartDate,
                CinemaName = reservation.CinemaName,
                Row = reservation.Row,
                Col = reservation.Col,
                RoomNumber = reservation.RoomNumber,
                ProjectionId = reservation.ProjectionId,
            };

            await this.ticketRepository.Insert(ticket);

            var returnModel = new TicketSummary(true)
            {
                TicketReservation = reservation
            };

            return returnModel;
        }
    }
}