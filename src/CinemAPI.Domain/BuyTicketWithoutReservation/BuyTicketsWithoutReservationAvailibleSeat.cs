using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.BuyTicketWithoutReservation
{
    public class BuyTicketsWithoutReservationAvailibleSeat : IBuyWithoutReservation
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly IBuyWithoutReservation buyWithoutReservation;

        public BuyTicketsWithoutReservationAvailibleSeat(IProjectionRepository projectionRepo, IBuyWithoutReservation buyWithoutReservation)
        {
            this.projectionRepo = projectionRepo;
            this.buyWithoutReservation = buyWithoutReservation;
        }

        public async Task<TicketSummary> Buy(ITicketCreate ticket)
        {
            var projection = await this.projectionRepo.Get(ticket.ProjectionId);

            if (projection.AvailableSeatsCount != 0)
            {
                ticket.ProjectionStartDate = projection.StartDate;

                return await this.buyWithoutReservation.Buy(ticket);
            }

            return new TicketSummary(false, "No aavailible seats");
        }
    }
}