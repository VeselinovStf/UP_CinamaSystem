using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using System.Threading.Tasks;

namespace CinemAPI.Domain.GetProjection
{
    public class GetProjection : IGetProjection
    {
        private readonly IProjectionRepository projectionsRepo;
        private readonly ICinemaRepository cinemaRepository;

        public GetProjection(IProjectionRepository projectionsRepo, ICinemaRepository cinemaRepository)
        {
            this.projectionsRepo = projectionsRepo;
            this.cinemaRepository = cinemaRepository;
        }

        public async Task<ProjectionSummary> Get(int projectionId)
        {
            var projectionRepoCall = await this.projectionsRepo.Get(projectionId);

            ProjectionSummary projSummary = new ProjectionSummary(false);

            if (projectionRepoCall != null)
            {
                projSummary.ProjectionStartDate = projectionRepoCall.StartDate;
                projSummary.RoomId = projectionRepoCall.RoomId;
                projSummary.MovieId = projectionRepoCall.MovieId;

                //Get Cinema name try repository
                var cinema = await this.cinemaRepository.GetRoomsByCinemaId(projSummary.RoomId);

                if (cinema != null)
                {
                    projSummary.CinemaName = cinema.Name;
                }
            }

            return projSummary;
        }
    }
}