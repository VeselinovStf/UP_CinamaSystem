using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.ModelFactory;
using System.Threading.Tasks;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class ReservationController : ApiController
    {
        private readonly INewReservation newReservation;

        private readonly IModelFactory modelFactory;
        private readonly ICancelReservation cancelReservation;

        public ReservationController(
            INewReservation newReservation,

            IModelFactory modelFactory,
            ICancelReservation cancelReservation)
        {
            this.newReservation = newReservation;

            this.modelFactory = modelFactory;
            this.cancelReservation = cancelReservation;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(int projectionId, int row, int col)
        {
            await this.cancelReservation.CancelReservationsTenMinutessBeforeProjection();

            NewReservationSummary newReservation = await this.newReservation.New(
                new Reservation(projectionId, row, col));

            if (newReservation.IsCreated)
            {
                return Ok(this.modelFactory.Create(newReservation.Reservation));
            }
            else
            {
                return BadRequest(newReservation.Message);
            }
        }
    }
}