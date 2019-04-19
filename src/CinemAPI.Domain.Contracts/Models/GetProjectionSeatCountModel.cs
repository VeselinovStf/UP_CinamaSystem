using System;

namespace CinemAPI.Domain.Contracts.Models
{
    public class GetProjectionSeatCountModel
    {
        public GetProjectionSeatCountModel(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public GetProjectionSeatCountModel(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }

        public int AvailableSeatsCount { get; set; }

        public DateTime ProjectionDurration { get; set; }
    }
}