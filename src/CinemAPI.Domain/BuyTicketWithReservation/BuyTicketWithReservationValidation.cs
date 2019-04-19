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
    public class BuyTicketWithReservationValidation : IBuyWithReservation
    {
        private readonly IReservationRepository reservationRepo;
        private readonly IBuyWithReservation buyWithoutReservation;

        public BuyTicketWithReservationValidation(IReservationRepository reservationRepo, IBuyWithReservation buyWithoutReservation)
        {
            this.reservationRepo = reservationRepo;
            this.buyWithoutReservation = buyWithoutReservation;
        }

        public async Task<TicketSummary> Buy(ITicketCreate ticket)
        {
            var reservation = await this.reservationRepo.GetByKey(ticket.Id);

            if (reservation == null)
            {
                return new TicketSummary(false, "Can't buy ticket without reservation");
            }

            return await this.buyWithoutReservation.Buy(ticket);
        }
    }
}