using CinemAPI.Models.Contracts.Projection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemAPI.Data
{
    public interface IProjectionRepository
    {
        Task UpdateAvailibleSeats(int value, int projectionId);

        Task<IProjection> Get(long projectionId);

        Task<IProjection> Get(int movieId, int roomId, DateTime startDate);

        Task Insert(IProjectionCreation projection);

        Task<IEnumerable<IProjection>> GetActiveProjections(int roomId);
    }
}