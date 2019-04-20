﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemAPI.Models.Output.Ticket
{
    public class TicketModel
    {
        public int Id { get; set; }
        public DateTime ProjectionStartDate { get; set; }
        public string MovieName { get; set; }
        public string CinemaName { get; set; }
        public int RoomNumber { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}