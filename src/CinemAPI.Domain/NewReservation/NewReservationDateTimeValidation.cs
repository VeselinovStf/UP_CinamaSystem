using CinemaAPI.DateTimeWraper;
using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
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
        private readonly IDateTimeWrapper dateTimeNow;

        public NewReservationDateTimeValidation(INewReservation newReservation, IMovieRepository movieRepo, IDateTimeWrapper dateTimeNow)
        {
            this.newReservation = newReservation;
            this.movieRepo = movieRepo;
            this.dateTimeNow = dateTimeNow;
        }

        public async Task<NewReservationSummary> New(IReservationCreation reservation)
        {
            var projectionStartDate = reservation.ProjectionStartDate;

            var movieRepoCall = await this.movieRepo.GetById(reservation.MovieId);

            var endTimeOfProjection = projectionStartDate.AddMinutes(movieRepoCall.DurationMinutes);

            var currentDateTime = this.dateTimeNow.GetDateTimeNow();

            NewReservationSummary summary = new NewReservationSummary(false);

            if (currentDateTime > endTimeOfProjection)
            {
                summary.Message = "Can't reserve place for finished projection";

                return summary;
            }

            if (currentDateTime > projectionStartDate)
            {
                summary.Message = "Can't reserve place for started projection ";

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