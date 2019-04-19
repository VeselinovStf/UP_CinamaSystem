using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Projection;
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

        public async Task<GetProjectionSeatCountModel> Get(IProjection projection)
        {
            if (projection.Id <= 0)
            {
                return new GetProjectionSeatCountModel(false, $"Projection Id is invalid : {projection.Id}");
            }

            return await seatsCount.Get(projection);
        }
    }
}