using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Model.Out
{
    public class CategoryDetailInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<MovieBasicInfoModel> Movies { get; set; }
    
        public CategoryDetailInfoModel(Category category) {
            this.Id = category.Id;
            this.Name = category.Name;
            this.Movies = category.CategoriesMovies.Select(cm => new MovieBasicInfoModel(cm.Movie)).ToList();
        }
    }
}