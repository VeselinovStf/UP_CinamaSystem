using System;

namespace CinemAPI.Models.Contracts.Reservation
{
    public interface IReservationCreation
    {
        long ProjectionId { get; set; }

        int MovieId { get; set; }
        int RoomId { get; set; }

        DateTime ProjectionStartDate { get; set; }
        string MovieName { get; set; }
        int Row { get; set; }
        int RoomNumber { get; set; }
        int Col { get; set; }
        string CinemaName { get; set; }
    }
}