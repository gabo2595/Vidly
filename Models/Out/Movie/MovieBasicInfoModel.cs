using Domain.Entities;

namespace Models.Out
{
    public class MovieBasicInfoModel
    {
        public MovieBasicInfoModel(Movie movie) {
            this.Id = movie.Id;
            this.Name = movie.Name;
            this.Description = movie.Description;
            this.AgeAllowed = movie.AgeAllowed;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AgeAllowed { get; set; }
    }
}