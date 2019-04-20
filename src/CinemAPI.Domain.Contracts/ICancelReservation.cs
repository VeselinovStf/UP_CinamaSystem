using CinemAPI.Domain.Contracts.Models;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts
{
    public interface ICancelReservation
    {
        Task<CancelReservationSummary> CancelReservationsTenMinutessBeforeProjection();
    }
}