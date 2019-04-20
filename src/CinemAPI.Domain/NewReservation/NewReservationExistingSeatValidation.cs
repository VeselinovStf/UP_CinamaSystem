using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewReservation
{
    /// <summary>
    /// Task
    /// </summary>
    public class NewReservationExistingSeatValidation : INewReservation
    {
        private readonly INewReservation newReservation;
        private readonly IRoomRepository roomRepository;

        public NewReservationExistingSeatValidation(ICinemaRepository cinemaRepo, INewReservation newReservation, IRoomRepository roomRepository)
        {
            this.newReservation = newReservation;
            this.roomRepository = roomRepository;
        }

        public async Task<NewReservationSummary> New(IReservationCreation reservation)
        {
            var room = await this.roomRepository.GetById(reservation.RoomId);

            if (room.Rows < reservation.Row || reservation.Row > room.Rows)
            {
                return new NewReservationSummary(false, "No such row in the room to reserve");
            }

            if (room.SeatsPerRow < reservation.Col || reservation.Col > room.SeatsPerRow)
            {
                return new NewReservationSummary(false, "No such colon in the room to reserve");
            }

            return await this.newReservation.New(reservation);
        }
    }
}