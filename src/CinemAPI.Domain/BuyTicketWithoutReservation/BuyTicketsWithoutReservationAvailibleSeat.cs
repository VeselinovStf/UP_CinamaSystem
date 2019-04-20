using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Ticket;
using System.Threading.Tasks;

namespace CinemAPI.Domain.BuyTicketWithoutReservation
{
    public class BuyTicketsWithoutReservationAvailibleSeat : IBuyWithoutReservation
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly IBuyWithoutReservation buyWithoutReservation;
        private readonly IRoomRepository roomRepo;
        private readonly ICinemaRepository cinemaRepo;
        private readonly ITicketRepository ticketRepository;

        public BuyTicketsWithoutReservationAvailibleSeat(
            IProjectionRepository projectionRepo,
            IBuyWithoutReservation buyWithoutReservation,
            IRoomRepository roomRepo,
            ICinemaRepository cinemaRepo,
            ITicketRepository ticketRepository)
        {
            this.projectionRepo = projectionRepo;
            this.buyWithoutReservation = buyWithoutReservation;
            this.roomRepo = roomRepo;
            this.cinemaRepo = cinemaRepo;
            this.ticketRepository = ticketRepository;
        }

        public async Task<TicketSummary> Buy(ITicketCreate ticket)
        {
            var projection = await this.projectionRepo.Get(ticket.ProjectionId);

            if (projection.AvailableSeatsCount != 0)
            {
                var soldTickets = await this.ticketRepository.Get(ticket.ProjectionId);

                if (soldTickets == null)
                {
                    var room = await this.roomRepo.GetById(projection.RoomId);
                    var cinema = await this.cinemaRepo.Get(room.CinemaId);

                    await this.projectionRepo.UpdateSingleAvailibleSeat(-1, projection.Id);

                    ticket.CinemaName = cinema.Name;

                    return await this.buyWithoutReservation.Buy(ticket);
                }
                else
                {
                    return new TicketSummary(false, "No availible seats, the seat is sold");
                }
            }

            return new TicketSummary(false, "No availible seats");
        }
    }
}