using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;

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
            var movies = this.moviesLogic.GetAll();
            
            return Ok(movies.Select(m => new MovieDetailInfoModel(m)).ToList());
        }

        // GET: api/movies/{id}
        [HttpGet("{id}")]
        public ActionResult<MovieDetailInfoModel> GetMovie(int id)
        {
            var movie = this.moviesLogic.GetById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(new MovieDetailInfoModel(movie));
        }

        // POST: api/movies
        [HttpPost]
        public ActionResult<MovieModel> CreateMovie(Movie movie)
        {
            this.moviesLogic.Create(movie);
            this.moviesLogic.SaveChanges();

            var newMovie = new MovieModel(movie);

            return CreatedAtAction("GetMovie", new { id = newMovie.Id }, newMovie);
        }

        // PUT: api/movies/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            if (!MovieExists(id))
            {
                return NotFound();
            }

            this.moviesLogic.Update(movie);
            this.moviesLogic.SaveChanges();

            return NoContent();
        }

        //DELETE api/movies/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var movie = this.moviesLogic.GetById(id);

            if(movie == null)
            {
                return NotFound();
            }

            this.moviesLogic.Delete(movie);
            this.moviesLogic.SaveChanges();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return moviesLogic.Exists(id);
        }
    }
}