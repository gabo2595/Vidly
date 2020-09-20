using System.Collections.Generic;
using Domain.Entities;

namespace BusinessLogicInterface.Interfaces
{
    public interface IMovieLogic
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Create(Movie movie);
        void Update(Movie movie);
        void Delete(Movie movie);
    }
}