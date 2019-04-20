using System;

namespace CinemAPI.Models.Contracts.Ticket
{
    public interface ITicketCreate
    {
        int Id { get; set; }
        DateTime ProjectionStartDate { get; set; }
        long ProjectionId { get; set; }
        string MovieName { get; set; }

        int MovieId { get; set; }
        string CinemaName { get; set; }
        int RoomNumber { get; set; }
        int Row { get; set; }
        int Col { get; set; }
    }
}