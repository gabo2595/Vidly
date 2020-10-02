using System.Collections.Generic;
using Domain.Entities;

namespace BusinessLogicInterface.Interfaces
{
    public interface IMovieLogic
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        Movie Add(Movie movie);
        void Update(int id, Movie movie);
        void Delete(int id);
    }
}