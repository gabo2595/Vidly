using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Create(Movie movie)
        {
            if(movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            this.moviesRepository.Create(movie);
        }

        public void Delete(Movie movie)
        {
            this.moviesRepository.Delete(movie);
        }

        public bool Exists(int id)
        {
            return this.moviesRepository.Exists(id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return this.moviesRepository.GetAll();
        }

        public Movie GetById(int id)
        {
            return this.moviesRepository.GetById(id);
        }

        public bool SaveChanges()
        {
            return this.moviesRepository.SaveChanges();
        }

        public void Update(Movie movie)
        {
            if(movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            this.moviesRepository.Update(movie);
        }
  }
}