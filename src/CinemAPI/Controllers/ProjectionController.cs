using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Input.Projection;
using CinemAPI.Models.ModelFactory;
using System.Threading.Tasks;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class ProjectionController : ApiController
    {
        private readonly INewProjection newProj;
        private readonly IProjectionSeatsCount seatCount;
        private readonly IModelFactory modelFactory;

        public ProjectionController(INewProjection newProj, IProjectionSeatsCount seatCount, IModelFactory modelFactory)
        {
            this.newProj = newProj;
            this.seatCount = seatCount;
            this.modelFactory = modelFactory;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetSeatsCount(int projectionId)
        {
            GetProjectionSeatCountModel summary = await seatCount.Get(new Projection(projectionId));

            if (summary.IsCreated)
            {
                var model = this.modelFactory.Create(summary);

                return Ok(model);
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