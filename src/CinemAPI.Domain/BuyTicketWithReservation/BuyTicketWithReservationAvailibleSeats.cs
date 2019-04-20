using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.BuyTicketWithReservation
{
    public class BuyTicketWithReservationAvailibleSeats : IBuyWithReservation
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly IBuyWithReservation buyWithReservation;
        private readonly IRoomRepository roomRepo;
        private readonly ICinemaRepository cinemaRepo;
        private readonly ITicketRepository ticketRepository;

        public BuyTicketWithReservationAvailibleSeats(
            IProjectionRepository projectionRepo,
            IBuyWithReservation buyWithReservation,
            IRoomRepository roomRepo,
           ICinemaRepository cinemaRepo,
           ITicketRepository ticketRepository)
        {
            this.projectionRepo = projectionRepo;
            this.buyWithReservation = buyWithReservation;
            this.roomRepo = roomRepo;
            this.cinemaRepo = cinemaRepo;
            this.ticketRepository = ticketRepository;
        }

        public async Task<TicketSummary> Buy(IReservation reservation)
        {
            var projection = await this.projectionRepo.Get(reservation.ProjectionId);

            if (projection.AvailableSeatsCount != 0)
            {
                var soldTickets = await this.ticketRepository.Get(reservation.ProjectionId);

                if (soldTickets == null)
                {
                    var room = await this.roomRepo.GetById(projection.RoomId);
                    var cinema = await this.cinemaRepo.Get(room.CinemaId);

                    await this.projectionRepo.UpdateSingleAvailibleSeat(-1, projection.Id);

                    reservation.CinemaName = cinema.Name;

                    return await this.buyWithReservation.Buy(reservation);
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