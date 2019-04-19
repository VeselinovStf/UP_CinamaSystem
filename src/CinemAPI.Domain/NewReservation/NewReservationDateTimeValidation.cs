using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewReservation
{
    /// <summary>
    /// Task
    /// </summary>
    public class NewReservationDateTimeValidation : INewReservation
    {
        private readonly INewReservation newReservation;
        private readonly IMovieRepository movieRepo;

        public NewReservationDateTimeValidation(INewReservation newReservation, IMovieRepository movieRepo)
        {
            this.newReservation = newReservation;
            this.movieRepo = movieRepo;
        }

        public async Task<NewReservationSummary> New(IReservationCreation reservation)
        {
            var projectionStartDate = reservation.ProjectionStartDate;

            var movieRepoCall = await this.movieRepo.GetById(reservation.MovieId);

            var endTimeOfProjection = projectionStartDate.AddMinutes(movieRepoCall.DurationMinutes);

            var currentDateTime = DateTime.UtcNow;

            NewReservationSummary summary = new NewReservationSummary(false);

            if (currentDateTime > endTimeOfProjection)
            {
                summary.Message = "Can't reserve place for finished projection";

                return summary;
            }

            if (currentDateTime.AddMinutes(9) >= projectionStartDate)
            {
                summary.Message = "Can't reserve place for projection starting in less than 10 minutes ";

                return summary;
            }

            return await this.newReservation.New(reservation);
        }
    }
}