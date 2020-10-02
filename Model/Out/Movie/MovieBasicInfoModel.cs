using Domain.Entities;

namespace Model.Out
{
    public class MovieBasicInfoModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int AgeAllowed { get; private set; }
        // public int CategoryId { get; private set; }
        
        public MovieBasicInfoModel(Movie movie)
        {
            this.Id = movie.Id;
            this.Name = movie.Name;
            this.Description = movie.Description;
            this.AgeAllowed = movie.AgeAllowed;
            // this.CategoryId = (int)movie.CategoryId;
        }

        public override bool Equals(object obj)
        {
            var result = false;
            
            if(obj is MovieBasicInfoModel movie)
            {
                result = this.Id == movie.Id && this.Name.Equals(movie.Name);
            }

            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}