using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationDecreaseSeats : INewReservation
    {
        private readonly IProjectionRepository projectionsRepo;
        private readonly INewReservation newReservation;

        public NewReservationDecreaseSeats(IProjectionRepository projectionsRepo, INewReservation newReservation)
        {
            this.projectionsRepo = projectionsRepo;
            this.newReservation = newReservation;
        }

        public async Task<NewReservationSummary> New(IReservationCreation reservation)
        {
            var projection = await this.projectionsRepo.Get(reservation.ProjectionId);

            var availibleSeats = projection.AvailableSeatsCount;

            if (availibleSeats > 0)
            {
                try
                {
                    await this.projectionsRepo.UpdateAvailibleSeats(-1, reservation.ProjectionId);

                    return await this.newReservation.New(reservation);
                }
                catch (Exception ex)
                {
                    return new NewReservationSummary(false, ex.Message);
                }
            }

            return new NewReservationSummary(false, "No Availible seats to reserve");
        }
    }
}