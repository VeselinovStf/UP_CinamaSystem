using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Room;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationRoomValidation : INewReservation
    {
        private readonly IRoomRepository roomRepo;
        private readonly INewReservation newReservation;

        public NewReservationRoomValidation(IRoomRepository roomRepo, INewReservation newReservation)
        {
            this.roomRepo = roomRepo;
            this.newReservation = newReservation;
        }

        public async Task<NewReservationSummary> New(IReservationCreation reservation)
        {
            IRoom room = await roomRepo.GetById(reservation.RoomId);

            if (room == null)
            {
                return new NewReservationSummary(false, $"Room with id {reservation.RoomId} does not exist");
            }
            else
            {
                reservation.RoomNumber = room.Number;
            }

            return await this.newReservation.New(reservation);
        }
    }
}