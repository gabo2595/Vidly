using Domain.Entities;

namespace Model.In
{
    public class MovieModel
    {
        public MovieModel(Movie movie) {
            this.Id = movie.Id;
            this.Name = movie.Name;
            this.Description = movie.Description;
            this.AgeAllowed = movie.AgeAllowed;
            this.CategoryId = (int)movie.CategoryId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AgeAllowed { get; set; }
        public int CategoryId { get; set; }
    }
}