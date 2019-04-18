using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Input.Projection;
using System.Threading.Tasks;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class ProjectionController : ApiController
    {
        private readonly INewProjection newProj;
        private readonly IProjectionSeatsCount seatCount;

        public ProjectionController(INewProjection newProj, IProjectionSeatsCount seatCount)
        {
            this.newProj = newProj;
            this.seatCount = seatCount;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetSeatsCount(int projectionId)
        {
            ProjectionSeatCountSummary summary = await seatCount.Get(projectionId);

            if (summary.IsCreated)
            {
                return Ok(summary.AvailableSeatsCount);
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Index(ProjectionCreationModel model)
        {
            if (ModelState.IsValid)
            {
                NewProjectionSummary summary = await newProj.New(new Projection(model.MovieId, model.RoomId, model.StartDate, model.AvailableSeatsCount));

                if (summary.IsCreated)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(summary.Message);
                }
            }

            return BadRequest();
        }
    }
}