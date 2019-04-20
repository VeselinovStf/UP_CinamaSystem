using CinemAPI.Domain.Contracts;
using CinemAPI.Models;
using CinemAPI.Models.ModelFactory;
using System.Threading.Tasks;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class TicketController : ApiController
    {
        private readonly IBuyWithoutReservation ticketWithoutReservation;
        private readonly ICancelReservation cancelReservations;
        private readonly IBuyWithReservation ticketWithReservation;
        private readonly IModelFactory modelFactory;

        public TicketController(
            IBuyWithoutReservation ticketWithoutReservation,
            ICancelReservation cancelReservations,
            IBuyWithReservation ticketWithReservation,
            IModelFactory modelFactory)
        {
            this.ticketWithoutReservation = ticketWithoutReservation;
            this.cancelReservations = cancelReservations;
            this.ticketWithReservation = ticketWithReservation;
            this.modelFactory = modelFactory;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Buy(int projectionId, int row, int col)
        {
            await this.cancelReservations.CancelReservationsTenMinutessBeforeProjection();

            var ticket = await this.ticketWithoutReservation.Buy(new Ticket(projectionId, row, col));

            if (ticket.IsCreated)
            {
                return Ok(this.modelFactory.Create(ticket.TicketReservation));
            }
            else
            {
                return BadRequest(ticket.Message);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Buy(int reservationKey)
        {
            await this.cancelReservations.CancelReservationsTenMinutessBeforeProjection();

            var ticket = await this.ticketWithReservation.Buy(new Reservation(reservationKey));

            if (ticket.IsCreated)
            {
                return Ok(this.modelFactory.Create(ticket.TicketReservation));
            }
            else
            {
                return BadRequest(ticket.Message);
            }
        }
    }
}