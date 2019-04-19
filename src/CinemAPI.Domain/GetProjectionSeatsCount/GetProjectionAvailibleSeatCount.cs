using CinemaAPI.DateTimeWraper;
using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Projection;
using System.Threading.Tasks;

namespace CinemAPI.Domain.GetProjectionSeatsCount
{
    public class GetProjectionAvailibleSeatCount : IProjectionSeatsCount
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly IMovieRepository movieRepository;
        private readonly IDateTimeWrapper dateTimeNowWrapper;

        public GetProjectionAvailibleSeatCount(

            IProjectionRepository projectionRepo,
            IMovieRepository movieRepository,
            IDateTimeWrapper dateTimeNowWrapper)
        {
            this.projectionRepo = projectionRepo;
            this.movieRepository = movieRepository;
            this.dateTimeNowWrapper = dateTimeNowWrapper;
        }

        public async Task<GetProjectionSeatCountModel> Get(IProjection projection)
        {
            GetProjectionSeatCountModel resultModel = new GetProjectionSeatCountModel(false);

            var movieRepoCall = await this.movieRepository.GetById(projection.MovieId);

            if (movieRepoCall == null)
            {
                resultModel.Message = "Can't find movie in to this projection";

                return resultModel;
            }

            var endTimeOfProjection = projection.StartDate.AddMinutes(movieRepoCall.DurationMinutes);

            var dateTimeNow = this.dateTimeNowWrapper.GetDateTimeNow();

            if (projection.StartDate > dateTimeNow)
            {
                resultModel.AvailableSeatsCount = projection.AvailableSeatsCount;
                resultModel.IsCreated = true;
            }

            if (dateTimeNow > endTimeOfProjection)
            {
                resultModel.Message = "Projection is finished";
            }
            else
            {
                resultModel.Message = "Projection is started";
            }

            return resultModel;
        }
    }
}