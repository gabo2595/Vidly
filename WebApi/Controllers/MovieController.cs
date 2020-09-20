using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Out;

namespace WebApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieLogic moviesLogic;

        public MovieController(IMovieLogic moviesLogic)
        {
            this.moviesLogic = moviesLogic;
        }

        // GET: api/movies
        [HttpGet]
        public ActionResult<IEnumerable<MovieDetailInfoModel>> GetAllMovies()
        {
            var movies = moviesLogic.GetAll();
            
            return Ok(movies.Select(m => new MovieDetailInfoModel(m)).ToList());
        }

        // GET: api/movies/{id}
        [HttpGet("{id}")]
        public ActionResult<MovieDetailInfoModel> GetMovie(int id)
        {
            var movie = moviesLogic.GetById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(new MovieDetailInfoModel(movie));
        }
    }
}