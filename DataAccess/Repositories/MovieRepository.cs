using System.Collections.Generic;
using System.Linq;
using DataAccessInterface.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DbSet<Movie> movies;
        private readonly DbContext vidlyContext;

        public MovieRepository(DbContext context)
        {
            this.vidlyContext = context;
            this.movies = context.Set<Movie>();
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
            return this.movies.ToList();
        }

        public Movie GetById(int id)
        {
            return this.movies.FirstOrDefault(m => m.Id == id);
        }

        public void Update(Movie movie)
        {
            throw new System.NotImplementedException();
        }
  }
}