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
    public class GetProjectionSeatsCountIdValidation : IProjectionSeatsCount
    {
        private readonly IProjectionSeatsCount seatsCount;
        private readonly IProjectionRepository projectionRepo;

        public GetProjectionSeatsCountIdValidation(IProjectionSeatsCount seatsCount, IProjectionRepository projectionRepo)
        {
            this.seatsCount = seatsCount;
            this.projectionRepo = projectionRepo;
        }

        public async Task<ProjectionSeatCountSummary> Get(long projectionId)
        {
            if (projectionId <= 0)
            {
                return new ProjectionSeatCountSummary(false, $"Projection Id is invalid : {projectionId}");
            }

            return await seatsCount.Get(projectionId);
        }
    }
}