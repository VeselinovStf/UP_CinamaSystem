using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Ticket;
using System;
using System.Threading.Tasks;

namespace CinemAPI.Domain.BuyTicketWithoutReservation
{
    public class BuyTicketsWithoutReservationDateTimeValidation : IBuyWithoutReservation
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly IBuyWithoutReservation buyWithoutReservation;
        private readonly IMovieRepository movieRepo;

        public BuyTicketsWithoutReservationDateTimeValidation(IProjectionRepository projectionRepo,
            IBuyWithoutReservation buyWithoutReservation,
            IMovieRepository movieRepo
            )
        {
            this.projectionRepo = projectionRepo;
            this.buyWithoutReservation = buyWithoutReservation;
            this.movieRepo = movieRepo;
        }

        public async Task<TicketSummary> Buy(ITicketCreate ticket)
        {
            var projection = await this.projectionRepo.Get(ticket.ProjectionId);

            var projectionStartDate = projection.StartDate;

            var movieRepoCall = await this.movieRepo.GetById(projection.MovieId);

            var endTimeOfProjection = projectionStartDate.AddMinutes(movieRepoCall.DurationMinutes);

            var currentDateTime = DateTime.UtcNow;

            TicketSummary summary = new TicketSummary(false);

            if (currentDateTime > endTimeOfProjection)
            {
                summary.Message = "Can't buy ticket finished projection";

                return summary;
            }

            if (currentDateTime <= endTimeOfProjection && currentDateTime >= projectionStartDate)
            {
                summary.Message = "Can't reserve place for started projection ";

                return summary;
            }

            ticket.MovieName = movieRepoCall.Name;
            ticket.ProjectionStartDate = projection.StartDate;
            ticket.ProjectionId = projection.Id;

            return await this.buyWithoutReservation.Buy(ticket);
        }
    }
}