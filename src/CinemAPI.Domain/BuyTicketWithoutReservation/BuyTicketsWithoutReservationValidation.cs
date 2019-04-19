using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Ticket;
using System.Threading.Tasks;

namespace CinemAPI.Domain.BuyTicketWithotuReservation
{
    public class BuyTicketsWithoutReservationValidation : IBuyWithoutReservation
    {
        private readonly IReservationRepository reservationRepo;
        private readonly IBuyWithoutReservation buyWithoutReservation;

        public BuyTicketsWithoutReservationValidation(IReservationRepository reservationRepo, IBuyWithoutReservation buyWithoutReservation)
        {
            this.reservationRepo = reservationRepo;
            this.buyWithoutReservation = buyWithoutReservation;
        }

        public async Task<TicketSummary> Buy(ITicketCreate ticket)
        {
            var reservation = await this.reservationRepo.GetByProjectionId(ticket.ProjectionId);

            //TODO: BUYED ENTITI
            if (reservation == null)
            {
                return await this.buyWithoutReservation.Buy(ticket);
            }

            return new TicketSummary(false);
        }
    }
}