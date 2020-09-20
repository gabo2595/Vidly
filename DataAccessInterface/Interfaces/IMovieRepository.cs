using System.Collections.Generic;
using Domain.Entities;

namespace DataAccessInterface.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Create(Movie movie);
        void Update(Movie movie);
        void Delete(Movie movie);
    }
}