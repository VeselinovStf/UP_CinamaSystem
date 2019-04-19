using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class ReservationController : ApiController
    {
        private readonly INewReservation newReservation;
        private readonly IGetProjection getProjection;

        public ReservationController(INewReservation newReservation, IGetProjection getProjection)
        {
            this.newReservation = newReservation;
            this.getProjection = getProjection;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(int projectionId, int row, int col)
        {
            NewReservationSummary newReservation = await this.newReservation.New(
                new Reservation(projectionId, row, col));

            //Decrease seat count

            if (newReservation.IsCreated)
            {
                return Ok(newReservation.Reservation);
            }
            else
            {
                return BadRequest(newReservation.Message);
            }
        }
    }
}