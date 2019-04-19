using CinemAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.GetReservations
{
    public class GetReservations
    {
        private readonly IReservationRepository reservationRepo;

        public GetReservations(IReservationRepository reservationRepo)
        {
            this.reservationRepo = reservationRepo;
        }

        public async Task Get(int projectionId, int col, int row)
        {
            // var reservations = await this.reservationRepo.GetByProjectionIdAndLocation(projectionId,row,col);
        }
    }
}