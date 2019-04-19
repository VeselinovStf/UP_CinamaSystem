﻿using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Models
{
    public class Reservation : IReservation, IReservationCreation
    {
        public Reservation()
        {
        }

        public Reservation(int projectionId, int row, int col)
        {
            this.ProjectionId = projectionId;
            this.Row = row;
            this.Col = col;
        }

        public Reservation(DateTime projectionStart, string movieName, string cinemaName, int roomNumber, int row, int column)
        {
            this.ProjectionStartDate = projectionStart;
            this.MovieName = movieName;
            this.CinemaName = cinemaName;
            this.RoomNumber = roomNumber;
            this.Row = row;
            this.Col = column;
        }

        public int Id { get; set; }
        public DateTime ProjectionStartDate { get; set; }
        public string MovieName { get; set; }
        public string CinemaName { get; set; }
        public int RoomNumber { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        //
        public int ProjectionId { get; set; }

        public int MovieId { get; set; }
        public int RoomId { get; set; }
    }
}