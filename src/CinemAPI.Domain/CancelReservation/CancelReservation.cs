using CinemaAPI.DateTimeWraper;
using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
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

            try
            {
                await this.projectionRepo.UpdateAvailibleSeats(1, reservations);
            }
            catch (System.Exception)
            {
                return new CancelReservationSummary(false, "Ten minutes limit for reservation is not followed!");
            }

            return new CancelReservationSummary(true);
        }
    }
}