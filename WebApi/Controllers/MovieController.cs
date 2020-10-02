using System;
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
        public IActionResult Get()
        {
            try
            {
                var movies = this.moviesLogic.GetAll();
                return Ok(movies.Select(m => new MovieDetailInfoModel(m)).ToList());
            }
            catch(ArgumentNullException)
            {
                return BadRequest();
            }
        }

        // GET: api/movies/{id}
        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult Get([FromRoute]int id)
        {
            try
            {
                var movie = this.moviesLogic.GetById(id);
                return Ok(new MovieDetailInfoModel(this.moviesLogic.GetById(id)));
            }
            catch(ArgumentNullException)
            {
                return NotFound();
            }
        }

        // POST: api/movies
        [HttpPost]
        public IActionResult Post([FromBody]MovieModel movieModel)
        {
            try
            {
                var movie = this.moviesLogic.Add(movieModel.ToEntity());
                return CreatedAtRoute("GetMovie", new {id = movie.Id },
                    new MovieDetailInfoModel(movie));
            }
            catch(ArgumentNullException)
            {
                return BadRequest();
            }
        }

        // PUT: api/movies/{id}
        [HttpPut("{id}")]
        public ActionResult Put([FromRoute]int id, [FromBody]MovieModel movie)
        {
            this.moviesLogic.Update(id, movie.ToEntity());
            return NoContent();
        }

        //DELETE api/movies/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            this.moviesLogic.Delete(id);
            return NoContent();
        }
    }
}