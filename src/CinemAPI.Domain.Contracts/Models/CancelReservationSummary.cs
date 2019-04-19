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