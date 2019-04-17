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

        public ProjectionController(INewProjection newProj)
        {
            this.newProj = newProj;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok("ooooooooolk");
        }
        [HttpPost]
        public async Task<IHttpActionResult> Index(ProjectionCreationModel model)
        {
            NewProjectionSummary summary =  await newProj.New(new Projection(model.MovieId, model.RoomId, model.StartDate));

            if (summary.IsCreated)
            {
                return Ok();
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }
    }
}