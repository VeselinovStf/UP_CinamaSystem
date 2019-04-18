using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.GetProjectionSeatsCount
{
    public class GetProjectionAvailibleSeatCount : IProjectionSeatsCount
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly IMovieRepository movieRepository;

        public GetProjectionAvailibleSeatCount(

            IProjectionRepository projectionRepo,
            IMovieRepository movieRepository)
        {
            this.projectionRepo = projectionRepo;
            this.movieRepository = movieRepository;
        }

        public async Task<ProjectionSeatCountSummary> Get(long projectionId)
        {
            var projectionRepoCall = await this.projectionRepo.Get(projectionId);

            ProjectionSeatCountSummary resultModel = new ProjectionSeatCountSummary(false);

            if (projectionRepoCall != null)
            {
                var movieRepoCall = await this.movieRepository.GetById(projectionRepoCall.MovieId);

                var endTimeOfProjection = projectionRepoCall.StartDate.AddMinutes(movieRepoCall.DurationMinutes);

                var dateTimeNow = DateTime.UtcNow;

                if (projectionRepoCall.StartDate > dateTimeNow)
                {
                    resultModel.AvailableSeatsCount = projectionRepoCall.AvailableSeatsCount;
                    resultModel.IsCreated = true;
                }
                else if (dateTimeNow > endTimeOfProjection)
                {
                    resultModel.Message = "Projection is finished";
                }
                else
                {
                    resultModel.Message = "Projection is started";
                }
            }

            return resultModel;
        }
    }
}