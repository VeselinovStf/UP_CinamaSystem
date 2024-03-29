﻿using CinemAPI.Data;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Movie;
using CinemAPI.Models.Input.Movie;
using System.Threading.Tasks;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class MovieController : ApiController
    {
        private readonly IMovieRepository movieRepo;

        public MovieController(IMovieRepository movieRepo)
        {
            this.movieRepo = movieRepo;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Index(MovieCreationModel model)
        {
            IMovie movie = await movieRepo.GetByNameAndDuration(model.Name, model.DurationMinutes);

            if (movie == null)
            {
                await movieRepo.Insert(new Movie(model.Name, model.DurationMinutes));

                return Ok();
            }

            return BadRequest("Movie already exists");
        }
    }
}