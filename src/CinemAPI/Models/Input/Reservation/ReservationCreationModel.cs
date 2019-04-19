using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemAPI.Models.Input.Reservation
{
    public class ReservationCreationModel
    {
        public DateTime ProjectionStartDate { get; set; }
        public string MovieName { get; set; }
        public string CinemaNameName { get; set; }
        public int RoomNumber { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}