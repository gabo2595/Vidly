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
            this.movies.Add(movie);
        }

        public void Delete(Movie movie)
        {
            this.movies.Remove(movie);
        }

        public bool Exists(int id)
        {
            return this.movies.Any(m => m.Id == id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return this.movies.ToList();
        }

        public Movie GetById(int id)
        {
            return this.movies.FirstOrDefault(m => m.Id == id);
        }

        public bool SaveChanges()
        {
            return (this.vidlyContext.SaveChanges() >= 0);
        }

        public void Update(Movie movie)
        {
            this.vidlyContext.Entry(movie).State = EntityState.Modified;
        }
  }
}