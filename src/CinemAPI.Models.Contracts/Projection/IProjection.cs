using System;

namespace CinemAPI.Models.Contracts.Projection
{
    public interface IProjection
    {
        long Id { get; set; }

        int RoomId { get; set; }

        int MovieId { get; set; }

        DateTime StartDate { get; set; }

        int AvailableSeatsCount { get; set; }
    }
}