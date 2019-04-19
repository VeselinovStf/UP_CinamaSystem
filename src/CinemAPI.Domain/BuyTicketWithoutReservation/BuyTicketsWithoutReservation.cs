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
    public class BuyTicketsWithoutReservation : IBuyWithoutReservation
    {
        private readonly IProjectionRepository projectionRepo;

        public BuyTicketsWithoutReservation(IProjectionRepository projectionRepo)
        {
            this.projectionRepo = projectionRepo;
        }
        public async Task<TicketSummary> Buy(ITicketCreate ticket)
        {
            var result = new TicketSummary(true)
            {
                Ticket = ticket
            };

            return result;
        }
    }
}