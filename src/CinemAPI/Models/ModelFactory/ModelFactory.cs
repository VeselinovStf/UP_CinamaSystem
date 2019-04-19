using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Output.Projection;

namespace CinemAPI.Models.ModelFactory
{
    public class ModelFactory : IModelFactory
    {
        public ProjectionSeatsCountModel Create(GetProjectionSeatCountModel model)
        {
            return new ProjectionSeatsCountModel()
            {
                AvailibleSeatsCount = model.AvailableSeatsCount
            };
        }
    }
}