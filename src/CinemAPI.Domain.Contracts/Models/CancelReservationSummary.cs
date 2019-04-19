using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models
{
    public class CancelReservationSummary
    {
        public CancelReservationSummary(bool isCreated)
        {
            this.IsCancelled = isCreated;
        }

        public CancelReservationSummary(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCancelled { get; set; }
    }
}