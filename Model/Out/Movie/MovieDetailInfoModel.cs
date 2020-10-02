using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Model.Out {
    public class MovieDetailInfoModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int AgeAllowed { get; private set; }

        public List<CategoryBasicInfoModel> Categories { get; set; }

        public MovieDetailInfoModel (Movie movie)
        {
            this.Id = movie.Id;
            this.Name = movie.Name;
            this.Description = movie.Description;
            this.AgeAllowed = movie.AgeAllowed;
            this.Categories = movie.CategoriesMovies.Select(cm => new CategoryBasicInfoModel(cm.Category)).ToList();
        }

        public override bool Equals(object obj)
        {
            var result = false;
            
            if(obj is MovieDetailInfoModel movie)
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