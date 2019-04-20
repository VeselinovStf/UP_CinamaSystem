using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Ticket;
using CinemAPI.Models.Output;
using CinemAPI.Models.Output.Projection;
using CinemAPI.Models.Output.Reservation;
using CinemAPI.Models.Output.Ticket;

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

        public ReservationTicketModel Create(IReservation model)
        {
            return new ReservationTicketModel()
            {
                Id = model.Id,
                ProjectionStartDate = model.ProjectionStartDate,
                CinemaName = model.CinemaName,
                Col = model.Col,
                MovieName = model.MovieName,
                RoomNumber = model.RoomNumber,
                Row = model.Row
            };
        }

        public TicketModel Create(ITicketCreate model)
        {
            return new TicketModel()
            {
                Id = model.Id,
                ProjectionStartDate = model.ProjectionStartDate,
                CinemaName = model.CinemaName,
                Col = model.Col,
                MovieName = model.MovieName,
                RoomNumber = model.RoomNumber,
                Row = model.Row
            };
        }
    }
}