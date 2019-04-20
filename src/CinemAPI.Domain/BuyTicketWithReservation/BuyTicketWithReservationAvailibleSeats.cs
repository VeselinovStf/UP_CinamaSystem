using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
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

        public BuyTicketWithReservationAvailibleSeats(IProjectionRepository projectionRepo, IBuyWithReservation buyWithReservation)
        {
            this.projectionRepo = projectionRepo;
            this.buyWithReservation = buyWithReservation;
        }

        public async Task<TicketSummary> Buy(ITicketCreate ticket)
        {
            var projection = await this.projectionRepo.Get(ticket.ProjectionId);

            if (projection.AvailableSeatsCount != 0)
            {
                await this.projectionRepo.UpdateSingleAvailibleSeat(-1, projection.Id);

                return await this.buyWithReservation.Buy(ticket);
            }

            return new TicketSummary(false, "No availible seats");
        }
    }
}