using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Models.Contracts.Ticket
{
    public interface ITicketCreate
    {
        int Id { get; set; }
        DateTime ProjectionStartDate { get; set; }
        int ProjectionId { get; set; }
        string MovieName { get; set; }

        int MovieId { get; set; }
        string CinemaName { get; set; }
        int RoomNumber { get; set; }
        int Row { get; set; }
        int Col { get; set; }
    }
}