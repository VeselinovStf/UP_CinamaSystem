using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models
{
    public class NewReservationSummary
    {
        public NewReservationSummary(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public NewReservationSummary(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }

        public IReservation Reservation { get; set; }
    }
}