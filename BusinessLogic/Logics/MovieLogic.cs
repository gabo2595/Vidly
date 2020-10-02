using System;
using System.Collections.Generic;
using BusinessLogicInterface.Interfaces;
using DataAccessInterface.Interfaces;
using Domain.Entities;

namespace BusinessLogic.Logics
{
    public class MovieLogic : IMovieLogic
    {
        private readonly IMovieRepository moviesRepository;

        public MovieLogic(IMovieRepository moviesRepository)
        {
            this.moviesRepository = moviesRepository;
        }

        public Movie Add(Movie movie)
        {
            if(movie == null)
            {
                throw new ArgumentNullException(nameof(movie), "Movie is invalid");
            }

            this.moviesRepository.Add(movie);
            this.moviesRepository.SaveChanges();

            return this.moviesRepository.GetById(movie.Id);
        }

        public void Delete(int id)
        {
            var movie = this.GetById(id);

            if(movie == null)
            {
                throw new ArgumentException("Movie doesn't exist", "Id:" + id);
            }

            this.moviesRepository.Delete(movie);
            this.moviesRepository.SaveChanges();
        }

        public IEnumerable<Movie> GetAll()
        {
            return this.moviesRepository.GetAll();
        }

        public Movie GetById(int id)
        {
            var movie = this.moviesRepository.GetById(id);

            if(movie == null)
            {
                throw new ArgumentNullException(nameof(movie), "movie doesn't exist");
            }

            return movie;
        }

        public void Update(int id, Movie movie)
        {
            if(movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            if(!this.moviesRepository.Exists(id))
            {
                throw new ArgumentException("Movie doesn't exist", "Id:" + id);
            }

            var movieToUpdate = this.GetById(id);

            this.moviesRepository.Update(movieToUpdate);
            this.moviesRepository.SaveChanges();
        }
  }
}