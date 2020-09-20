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
            throw new System.NotImplementedException();
        }

        public void Delete(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            return this.moviesRepository.GetAll();
        }

        public Movie GetById(int id)
        {
            return this.moviesRepository.GetById(id);
        }

        public void Update(Movie movie)
        {
            throw new System.NotImplementedException();
        }
  }
}