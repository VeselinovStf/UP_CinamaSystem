using CinemAPI.Models.Contracts.Projection;
using System;

namespace CinemAPI.Models
{
    public class Projection : IProjection, IProjectionCreation
    {
        private readonly int availibleSeatsCount;

        public Projection()
        {
        }

        public Projection(int movieId, int roomId, DateTime startdate, int availibleSeatsCount)
        {
            this.MovieId = movieId;
            this.RoomId = roomId;
            this.StartDate = startdate;
            this.availibleSeatsCount = availibleSeatsCount;
        }

        public long Id { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public DateTime StartDate { get; set; }

        public int AvailableSeatsCount { get; set; }
    }
}