using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Projection;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts
{
    public interface IProjectionSeatsCount
    {
        Task<GetProjectionSeatCountModel> Get(IProjection projection);
    }
}