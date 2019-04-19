using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationProjectionValidation : INewReservation
    {
        private readonly IProjectionRepository projectionsRepo;
        private readonly INewReservation newReservation;

        public NewReservationProjectionValidation(IProjectionRepository projectionsRepo, INewReservation newReservation)
        {
            this.projectionsRepo = projectionsRepo;
            this.newReservation = newReservation;
        }

        public async Task<NewReservationSummary> New(IReservationCreation reservation)
        {
            var projectionRepoCall = await this.projectionsRepo.Get(reservation.ProjectionId);

            if (projectionRepoCall != null)
            {
                reservation.ProjectionStartDate = projectionRepoCall.StartDate;
                reservation.RoomId = projectionRepoCall.RoomId;
                reservation.MovieId = projectionRepoCall.MovieId;
            }
            else
            {
                return new NewReservationSummary(false, "Can't find projection with this ip to reserve in");
            }

            return await this.newReservation.New(reservation);
        }
    }
}