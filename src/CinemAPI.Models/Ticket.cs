using CinemAPI.Models.Contracts.Ticket;
using System;

namespace CinemAPI.Models
{
    public class Ticket : ITicket, ITicketCreate
    {
        public Ticket()
        {
        }

        public Ticket(int id)
        {
            this.Id = id;
        }

        public Ticket(int projectionId, int row, int col)
        {
            this.ProjectionId = projectionId;
            this.Row = row;
            this.Col = col;
        }

        public Ticket(DateTime projectionStart, string movieName, string cinemaName, int roomNumber, int row, int column, int projectionId)
        {
            this.ProjectionStartDate = projectionStart;
            this.MovieName = movieName;
            this.CinemaName = cinemaName;
            this.RoomNumber = roomNumber;
            this.Row = row;
            this.Col = column;
            this.ProjectionId = projectionId;
        }

        public int Id { get; set; }
        public DateTime ProjectionStartDate { get; set; }
        public string MovieName { get; set; }
        public string CinemaName { get; set; }
        public int RoomNumber { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public long ProjectionId { get; set; }
        public int MovieId { get; set; }
    }
}