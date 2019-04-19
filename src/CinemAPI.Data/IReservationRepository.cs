using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemAPI.Data
{
    public interface IReservationRepository
    {
        Task Insert(IReservationCreation projection);

        Task<IReservation> GetSpecificReservation(
            DateTime projectionStartDate,
            string movieName,
            string cinemaName,
            int roomNumber,
            int row,
            int col);

        Task<IReservation> GetByProjectionId(int projectionId);

        Task<IReservation> GetByKey(int key);

        Task<IEnumerable<IReservation>> GetByProjectionTime(DateTime before);
    }
}