using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Cinema;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Room;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationCinemaValidation : INewReservation
    {
        private readonly ICinemaRepository cinemaRepo;
        private readonly INewReservation newReservation;
        private readonly IRoomRepository roomRepository;

        public NewReservationCinemaValidation(ICinemaRepository cinemaRepo, INewReservation newReservation, IRoomRepository roomRepository)
        {
            this.cinemaRepo = cinemaRepo;
            this.newReservation = newReservation;
            this.roomRepository = roomRepository;
        }

        public async Task<NewReservationSummary> New(IReservationCreation reservation)
        {
            IRoom room = await roomRepository.GetById(reservation.RoomId);

            ICinema cinema = await cinemaRepo.GetRoomsByCinemaId(room.CinemaId);

            if (cinema == null)
            {
                return new NewReservationSummary(false, $"Cinema with room id {reservation.RoomId} does not exist");
            }
            else
            {
                reservation.CinemaName = cinema.Name;
            }

            return await this.newReservation.New(reservation);
        }
    }
}