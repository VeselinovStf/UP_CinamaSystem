using CinemAPI.Domain.Contracts;
using CinemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class TicketController : ApiController
    {
        private readonly IBuyWithoutReservation ticketWithoutReservation;
        private readonly ICancelReservation cancelReservations;
        private readonly IBuyWithReservation ticketWithReservation;

        public TicketController(
            IBuyWithoutReservation ticketWithoutReservation,
            ICancelReservation cancelReservations,
            IBuyWithReservation ticketWithReservation)
        {
            this.ticketWithoutReservation = ticketWithoutReservation;
            this.cancelReservations = cancelReservations;
            this.ticketWithReservation = ticketWithReservation;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Bye(int projectionId, int row, int col)
        {
            await this.cancelReservations.Cancel();

            var ticket = await this.ticketWithoutReservation.Buy(new Ticket(projectionId, row, col));

            if (ticket.IsCreated)
            {
                return Ok(ticket);
            }
            else
            {
                return BadRequest(ticket.Message);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Bye(int reservationKey)
        {
            await this.cancelReservations.Cancel();

            var ticket = await this.ticketWithReservation.Buy(new Ticket(reservationKey));

            if (ticket.IsCreated)
            {
                return Ok(ticket);
            }
            else
            {
                return BadRequest(ticket.Message);
            }
        }
    }
}