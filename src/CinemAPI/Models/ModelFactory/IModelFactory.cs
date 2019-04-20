using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Ticket;
using CinemAPI.Models.Output;
using CinemAPI.Models.Output.Projection;
using CinemAPI.Models.Output.Reservation;
using CinemAPI.Models.Output.Ticket;

namespace CinemAPI.Models.ModelFactory
{
    public interface IModelFactory
    {
        ProjectionSeatsCountModel Create(GetProjectionSeatCountModel model);

        ReservationTicketModel Create(IReservation model);

        TicketModel Create(ITicketCreate model);
    }
}