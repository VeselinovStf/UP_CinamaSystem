using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Output.Projection;

namespace CinemAPI.Models.ModelFactory
{
    public interface IModelFactory
    {
        ProjectionSeatsCountModel Create(GetProjectionSeatCountModel model);
    }
}