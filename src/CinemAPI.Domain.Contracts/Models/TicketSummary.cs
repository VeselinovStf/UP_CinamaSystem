using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models
{
    public class TicketSummary
    {
        public TicketSummary(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public TicketSummary(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }

        public ITicketCreate Ticket { get; set; }
    }
}