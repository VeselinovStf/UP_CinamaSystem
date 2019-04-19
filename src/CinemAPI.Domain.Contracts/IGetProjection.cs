using CinemAPI.Domain.Contracts.Models;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts
{
    public interface IGetProjection
    {
        Task<ProjectionSummary> Get(int projectionId);
    }
}