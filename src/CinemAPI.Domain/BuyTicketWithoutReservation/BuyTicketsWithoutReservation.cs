using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Ticket;
using System.Threading.Tasks;

namespace CinemAPI.Domain.BuyTicketWithoutReservation
{
    public class BuyTicketsWithoutReservation : IBuyWithoutReservation
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly ITicketRepository ticketRepository;

        public BuyTicketsWithoutReservation(IProjectionRepository projectionRepo, ITicketRepository ticketRepository)
        {
            this.projectionRepo = projectionRepo;
            this.ticketRepository = ticketRepository;
        }
        public async Task<TicketSummary> Buy(ITicketCreate ticket)
        {
            IReservation reservation = new Reservation()
            {
                MovieName = ticket.MovieName,
                ProjectionStartDate = ticket.ProjectionStartDate,
                CinemaName = ticket.CinemaName,
                Row = ticket.Row,
                Col = ticket.Col,
                RoomNumber = ticket.RoomNumber,
                ProjectionId = ticket.ProjectionId,
            };

            await this.ticketRepository.Insert(ticket);

            var result = new TicketSummary(true)
            {
                TicketReservation = reservation
            };

            return result;
        }
    }
}