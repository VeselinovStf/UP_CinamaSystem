using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Models.Contracts.Reservation
{
    public interface IReservation
    {
        int Id { get; set; }

        DateTime ProjectionStartDate { get; set; }
        string MovieName { get; set; }
        string CinemaName { get; set; }
        int RoomNumber { get; set; }
        int Row { get; set; }
        int Col { get; set; }
    }
}