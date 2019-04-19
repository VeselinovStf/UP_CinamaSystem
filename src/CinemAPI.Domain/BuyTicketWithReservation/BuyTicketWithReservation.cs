using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Ticket;
using System.Threading.Tasks;

namespace CinemAPI.Domain.BuyTicketWithReservation
{
    public class BuyTicketWithReservation : IBuyWithReservation
    {
        private readonly IReservationRepository reservationRepo;

        public BuyTicketWithReservation(IReservationRepository reservationRepo)
        {
            this.reservationRepo = reservationRepo;
        }

        public async Task<TicketSummary> Buy(ITicketCreate ticket)
        {
            var returnModel = new TicketSummary(true)
            {
                Ticket = ticket
            };

            return returnModel;
        }
    }
}