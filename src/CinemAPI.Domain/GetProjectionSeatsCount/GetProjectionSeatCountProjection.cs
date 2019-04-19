using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Projection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.GetProjectionSeatsCount
{
    //2
    public class GetProjectionSeatCountProjection : IProjectionSeatsCount
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly IProjectionSeatsCount projectioSeatCount;

        public GetProjectionSeatCountProjection(

            IProjectionRepository projectionRepo,
            IProjectionSeatsCount projectioSeatCount
          )
        {
            this.projectionRepo = projectionRepo;
            this.projectioSeatCount = projectioSeatCount;
        }

        public async Task<GetProjectionSeatCountModel> Get(IProjection projection)
        {
            var projectionRepoCall = await this.projectionRepo.Get(projection.Id);

            if (projectionRepoCall == null)
            {
                return new GetProjectionSeatCountModel(false, $"Cant find projection with this id: {projection.Id}");
            }
            else
            {
                projection.MovieId = projectionRepoCall.MovieId;
                projection.AvailableSeatsCount = projectionRepoCall.AvailableSeatsCount;
                projection.StartDate = projectionRepoCall.StartDate;
            }

            return await this.projectioSeatCount.Get(projection);
        }
    }
}