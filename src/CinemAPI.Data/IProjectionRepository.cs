using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemAPI.Data
{
    public interface IProjectionRepository
    {
        Task UpdateSingleAvailibleSeat(int value, long projectionId);

        Task UpdateAvailibleSeats(int value, IEnumerable<IReservation> reservations);

        Task<IProjection> Get(long projectionId);

        Task<IProjection> Get(int movieId, int roomId, DateTime startDate);

        Task Insert(IProjectionCreation projection);

        Task<IEnumerable<IProjection>> GetActiveProjections(int roomId);
    }
}