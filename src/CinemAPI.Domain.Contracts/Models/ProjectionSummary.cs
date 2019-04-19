using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models
{
    public class ProjectionSummary
    {
        public ProjectionSummary(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public ProjectionSummary(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public ProjectionSummary(bool status, string msg,
            DateTime projectionStartDate,
            string movieName,
            string cinemaName,
            int roomId,
            int movieId)
        {
            this.ProjectionStartDate = projectionStartDate;
            this.MovieName = movieName;
            this.CinemaName = cinemaName;
            this.RoomId = roomId;
            this.MovieId = movieId;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }

        public DateTime ProjectionStartDate { get; set; }
        public string MovieName { get; set; }
        public string CinemaName { get; set; }
        public int RoomId { get; set; }

        public int MovieId { get; set; }
    }
}