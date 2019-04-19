using CinemaAPI.DateTimeWraper;
using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.CancelReservation
{
    public class CancelReservation : ICancelReservation
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly IReservationRepository reservationRepo;
        private readonly IDateTimeWrapper dateTimeNow;

        public CancelReservation(IProjectionRepository projectionRepo, IReservationRepository reservationRepo, IDateTimeWrapper dateTimeNow)
        {
            this.projectionRepo = projectionRepo;
            this.reservationRepo = reservationRepo;
            this.dateTimeNow = dateTimeNow;
        }

        public async Task<CancelReservationSummary> Cancel()
        {
            var currentTime = this.dateTimeNow.GetDateTimeNow();

            var addedTime = currentTime.AddMinutes(10);

            var reservations = await this.reservationRepo.GetByProjectionTime(addedTime);

            if (reservations == null)
            {
                return new CancelReservationSummary(false, "No Reservations to cancel");
            }

            foreach (var item in reservations)
            {
                await this.projectionRepo.UpdateAvailibleSeats(1, item.ProjectionId);
            }

            return new CancelReservationSummary(true);
        }
    }
}